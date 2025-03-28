using System;
using UnityEngine;

namespace GamePlay.Script
{
    public class SpawnNote : MonoBehaviour
    {
        public AudioSource audio;
        public LogicScript logic;
        public GameObject note;
        private float timeSpawn = 0.5f;
        private float time;
        private float timeStart;

        public double[] timingList;
        private float dspSongTime;
        private float songPosition;
        private float songLength;
        private string listJson;
        private int index;

        private void Start()
        {
            if (Date.Difficult == 0)
                timingList = TimingArrayEasy();
            else
                timingList = TimingArrayNormal();
            timeStart = 0;
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
            audio.volume = Date.VolumeSong;
            audio.clip = Resources.Load<AudioClip>("sunset_butttttttt");
            dspSongTime = (float)AudioSettings.dspTime;
            songLength = audio.clip.length;
            audio.Play();
            audio.time = timeStart;
            Date.MaxScore = timingList.Length * 200 + timingList.Length / 2 * timingList.Length;
        }

        void Update()
        {
            logic.UpdateProgressBar((audio.time - timeStart) / (audio.clip.length - timeStart));
            songPosition = (float)(AudioSettings.dspTime - dspSongTime);
            if (index < timingList.Length && songPosition > timingList[index] - 10.0f / 6.0f)
            {
                Instantiate(note);
                index++;
            }

            if (songPosition > songLength)
            {
                logic.EndSong();
            }
        }

        private double[] TimingArrayNormal()
        {
            return new[]
            {
                16.981338500976564,
                18.901338577270509,
                20.84267234802246,
                22.656005859375,
                24.490671157836915,
                26.368005752563478,
                28.288005828857423,
                30.122671127319337,
                31.104005813598634,
                31.552005767822267,
                32.98133850097656,
                33.42933654785156,
                34.858673095703128,
                35.306671142578128,
                36.73600387573242,
                37.16267013549805,
                39.50933837890625,
                41.38667297363281,
                43.242671966552737,
                45.16267013549805,
                46.08000564575195,
                46.97600555419922,
                47.9146728515625,
                48.874671936035159,
                49.83467102050781,
                50.79467010498047,
                51.690670013427737,
                52.629337310791019,
                53.5680046081543,
                54.50667190551758,
                55.466670989990237,
                56.42667007446289,
                57.3440055847168,
                58.26133728027344,
                59.178672790527347,
                60.160003662109378,
                61.1200065612793,
                62.03733825683594,
                62.95466995239258,
                63.89333724975586,
                64.8320083618164,
                65.81333923339844,
                66.73067474365235,
                67.66934204101563,
                68.60800170898438,
                69.54666900634766,
                70.52800750732422,
                71.4453353881836,
                72.3626708984375,
                73.30133819580078,
                74.19734191894531,
                75.13600158691406,
                77.0560073852539,
                78.89067077636719,
                80.78933715820313,
                82.66667175292969,
                84.56533813476563,
                86.4000015258789,
                88.29866790771485,
                90.15467071533203,
                91.60533905029297,
                93.41867065429688,
                95.3600082397461,
                97.15200805664063,
                98.9866714477539,
                100.9493408203125,
                105.08800506591797,
                106.96533966064453,
                108.90666961669922,
                110.74134063720703,
                112.66133880615235,
                114.56000518798828,
                116.43733978271485,
                118.35733795166016,
                121.9840087890625,
                123.90400695800781,
                126.25067138671875,
                128.1493377685547,
                128.5760040283203,
                129.0240020751953,
                129.51467895507813,
                129.96267700195313,
                130.4320068359375,
                130.92266845703126,
                131.41334533691407,
                131.86134338378907,
                132.33067321777345,
                132.8213348388672,
                133.29066467285157,
                135.12533569335938,
                136.0426788330078,
                137.0453338623047,
                137.9840087890625,
                138.92266845703126,
                139.8400115966797,
                140.77867126464845,
                141.67466735839845,
                142.656005859375,
                143.57333374023438,
                144.4906768798828,
                145.42933654785157,
                146.38934326171876,
                147.3280029296875,
                148.24533081054688,
                149.1626739501953,
                150.12266540527345,
                151.04000854492188,
                151.552001953125,
                152.0426788330078,
                152.4906768798828,
                152.9386749267578,
                153.4080047607422,
                153.8560028076172,
                154.38934326171876,
                154.83734130859376,
                155.30667114257813,
                155.79733276367188,
                156.2666778564453,
                156.67201232910157,
                157.1626739501953,
                157.6320037841797,
                158.12266540527345,
                158.59201049804688,
                159.10400390625,
                159.552001953125,
                160.0426788330078,
                160.4906768798828,
                160.9386749267578,
                161.3866729736328,
                161.8560028076172,
                162.32533264160157,
                162.794677734375,
                163.28533935546876,
                163.7760009765625,
                164.24533081054688,
                164.7146759033203,
                165.1840057373047,
                166.0586700439453,
                167.0186767578125,
                168.0,
                168.9386749267578,
                169.8560028076172,
                170.794677734375,
                171.7760009765625,
                172.62933349609376,
                173.6320037841797,
                174.54933166503907,
                175.53067016601563,
                176.42666625976563,
                177.3866729736328,
                178.3040008544922,
                179.20001220703126,
                180.16000366210938,
                182.01600646972657,
                183.97866821289063,
                187.62667846679688,
                189.50399780273438,
                191.44534301757813,
                195.0933380126953
            };
        }

        private double[] TimingArrayEasy()
        {
            return new[]
            {
                17.02394676208496,
                18.943946838378908,
                20.77861213684082,
                22.613279342651368,
                24.469280242919923,
                26.410612106323243,
                30.229280471801759,
                31.99994659423828,
                33.919944763183597,
                35.77594757080078,
                37.6319465637207,
                39.509281158447269,
                41.38661193847656,
                46.101280212402347,
                47.957279205322269,
                49.77061462402344,
                51.669281005859378,
                53.56794738769531,
                55.44527816772461,
                57.3012809753418,
                59.15727996826172,
                60.62928009033203,
                61.5252799987793,
                62.44261169433594,
                63.359947204589847,
                64.29861450195313,
                65.2372817993164,
                66.17594909667969,
                67.11461639404297,
                68.05327606201172,
                69.0132827758789,
                69.95195007324219,
                70.89060974121094,
                71.85061645507813,
                72.7679443359375,
                73.70661163330078,
                74.64527893066406,
                76.47994995117188,
                82.62394714355469,
                84.47994995117188,
                90.06928253173828,
                91.51994323730469,
                92.97061157226563,
                95.25328063964844,
                97.15194702148438,
                99.00794982910156,
                100.8852767944336,
                121.98394775390625,
                123.86128234863281,
                125.75994873046875,
                127.67994689941406,
                129.51461791992188,
                131.4132843017578,
                135.12527465820313,
                136.04261779785157,
                136.95994567871095,
                137.8986053466797,
                138.8372802734375,
                139.7972869873047,
                140.73594665527345,
                141.73861694335938,
                142.59194946289063,
                143.53060913085938,
                144.4692840576172,
                145.4292755126953,
                146.34661865234376,
                147.32794189453126,
                148.2452850341797,
                149.18394470214845,
                150.61328125,
                151.53060913085938,
                152.4479522705078,
                153.38661193847657,
                154.34661865234376,
                155.2852783203125,
                156.1812744140625,
                157.16261291503907,
                158.07994079589845,
                159.03994750976563,
                159.97860717773438,
                160.87461853027345,
                161.8132781982422,
                162.79461669921876,
                163.7332763671875,
                164.65061950683595,
                166.54928588867188,
                168.38394165039063,
                174.05860900878907,
                175.8719482421875,
                187.62661743164063
            };
        }
    }
}
