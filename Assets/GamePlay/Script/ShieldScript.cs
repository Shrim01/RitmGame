using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GamePlay.Script
{
    public class ShieldScript : MonoBehaviour
    {
        public Queue<GameObject> touchsObject = new Queue<GameObject>();
        public LogicScript logic;
        public string[] inputsKey = {"x","z"};

        private void Start()
        {
            transform.position = new Vector3(Date.RadiusCircle,0,0);
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        }

        private void Update()
        {
            if (touchsObject.Count!=0 && inputsKey.Any(Input.GetKeyDown) || Input.GetMouseButtonDown(0))
            {
                var touchObject = touchsObject.Dequeue(); //Объект может быть null
                var distanse = (transform.position-touchObject.transform.position).magnitude;
                logic.AddScore(distanse);
                Destroy(touchObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        { 
            touchsObject.Enqueue(other.gameObject);
            Debug.Log(touchsObject.Count);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            //Надо удалить объект из очереди, если он перестает касаться щита
        }
    }
}
