using UnityEngine;

namespace GamePlay.Script
{
    public class MusicScript : MonoBehaviour
    {
        public AudioSource audio;
        public LogicScript logic;

        void Start()
        {
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
            audio.volume = Date.VolumeSong;
            audio.PlayScheduled(35.0f);
        }

        private void Update()
        {
            logic.UpdateProgressBar(audio.time/audio.clip.length);
        }
    }
}
