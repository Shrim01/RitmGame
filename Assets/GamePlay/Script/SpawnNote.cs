using UnityEngine;

namespace GamePlay.Script
{
    public class SpawnNote : MonoBehaviour
    {
        public GameObject note;
        private float timeSpawn = 0.5f;
        private float time;


        void Update()
        {
            time+=Time.deltaTime;
            if (time>timeSpawn)
            {
                Instantiate(note);
                time = 0;
            }
        }
    }
}
