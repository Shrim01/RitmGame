using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GamePlay.Script
{
    public class ShieldScript : MonoBehaviour
    {
        private readonly Queue<GameObject> touchsObject = new();
        public LogicScript logic;
        public string[] inputsKey = { "x", "z" };

        private void Start()
        {
            transform.position = new Vector3(Date.RadiusCircle, 0, 0);
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        }

        private void Update()
        {
            if (inputsKey.Any(Input.GetKeyDown) || Input.GetMouseButtonDown(0))
            {
                while (touchsObject.Count != 0)
                {
                    var touchObject = touchsObject.Dequeue();
                    if (touchObject is null)
                    {
                        logic.Miss();
                        continue;
                    }

                    var distanse = (transform.position - touchObject.transform.position).magnitude;
                    logic.AddScore(distanse);
                    Destroy(touchObject);
                    break;
                }
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
            if (!touchsObject.Contains(other.gameObject)) return;
            while (touchsObject.Count != 0)
            {
                var touch = touchsObject.Dequeue();
                if (touch == other.gameObject)
                    return;
            }
        }
    }
}