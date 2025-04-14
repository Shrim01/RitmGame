using UnityEngine;
using System.Collections;

namespace GamePlay.Script
{
    public class ShieldScript : MonoBehaviour
    {
        private bool touch;
        private GameObject touchObject;
        public LogicScript logic;
        private SpriteRenderer spriteRenderer;

        [Header("Shield Sprites")]
        public Sprite normalShield;
        public Sprite newShield;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            transform.position = new Vector3(Date.RadiusCircle, 0, 0);
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
            touch = false;
            spriteRenderer.sprite = normalShield;
        }

        private void Update()
        {
            if (touch && (Input.GetKeyDown("x") || Input.GetKeyDown("z")))
            {
                StartCoroutine(ShieldHitEffect());
                var distance = (transform.position - touchObject.transform.position).magnitude;
                logic.AddScore(distance);
                Destroy(touchObject);
            }
        }

        private IEnumerator ShieldHitEffect()
        {
            spriteRenderer.sprite = newShield;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.sprite = normalShield;
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