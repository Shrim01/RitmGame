using System;
using System.Linq;
using UnityEngine;

namespace GamePlay.Script
{
    public class SpawnNote : MonoBehaviour
    {
        public new AudioSource audio;
        public LogicScript logic;
        public GameObject note;
        public GameObject longNote;
        public GameObject spinner;
        private float timeSpawn = 5f;
        private float time;
        private float timeStart;

        private float[] noteTiming;
        private (float start,float end)[] longNoteTiming;
        private (float start,float end)[] spinnerTiming;
        private float dspSongTime;
        private float songPosition;
        private float songLength;
        private string listJson;
        private int[] index = {0,0,0};

        private void Start()
        {
            audio.clip = Resources.Load<AudioClip>("sunset_butttttttt");
            listJson = Resources.Load<TextAsset>("sunset_butttttttt_text").ToString();
            TimingArrayNormal();
            // if (Date.Difficult == 0)
            // timingList = TimingArrayEasy();
            timeStart = 0;
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
            audio.volume = Date.VolumeSong;
            dspSongTime = (float)AudioSettings.dspTime;
            songLength = audio.clip.length;
            audio.Play();
            audio.time = timeStart;
            // Date.MaxScore = timingList.Length * 200 + timingList.Length / 2 * timingList.Length;
        }

        public void Update()
        {
            logic.UpdateProgressBar((audio.time - timeStart) / (audio.clip.length - timeStart));
            songPosition = (float)(AudioSettings.dspTime - dspSongTime);
            SpawnNotes();
            if (songPosition > songLength)
                logic.EndSong();
            
        }

        private void SpawnNotes()
        {
            if (index[0]<noteTiming.Length && songPosition>noteTiming[index[0]])
            {
                Instantiate(note);
                index[0]++;
            }
        
            if (index[1]<longNoteTiming.Length && songPosition>longNoteTiming[index[1]].start)
            {
                Instantiate(longNote);
                index[1]++;
            }
            
            if (index[2]<spinnerTiming.Length && songPosition>spinnerTiming[index[2]].start)
            {
                Instantiate(spinner);
                index[2]++;
            }
        }

        private void TimingArrayNormal()
        {
            var timing = JsonUtility.FromJson<NoteRecord<float>>(listJson);
            noteTiming = timing.Note;
            longNoteTiming = ParsingTiming(timing.LongNote);
            spinnerTiming = ParsingTiming(timing.Spinner);
        }

        private (float start, float end)[] ParsingTiming(string[] timings)
        {
            return timings.Select(x =>
            {
                var a = x.Split()
                    .Select(float.Parse)
                    .ToArray();
                return (a[0], a[1]);
            }).ToArray();
        }
    }
}