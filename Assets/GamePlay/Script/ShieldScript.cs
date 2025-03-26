using UnityEngine;

namespace GamePlay.Script
{
    public class ShieldScript : MonoBehaviour
    {
        private bool touch;
        private GameObject touchObject;
        public LogicScript logic;

        private void Start()
        {
            transform.position = new Vector3(Date.RadiusCircle,0,0);
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
            touch = false;
        }

        private void Update()
        {
            if (touch && (Input.GetKeyDown("x") || Input.GetKeyDown("z")))
            {
                var distanse = (transform.position-touchObject.transform.position).magnitude;
                logic.AddScore(distanse);
                Destroy(touchObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            touch = true;
            touchObject = other.gameObject;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            touch = false;
            touchObject = null;
        }
    }
}
