using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlay.Script
{
    public class MusicScript : MonoBehaviour
    {
        public AudioSource audio;

        void Start()
        {
            audio.clip = Date.Song;
            audio.volume = Date.VolumeSong;
            audio.Play();
        }
    }
}
