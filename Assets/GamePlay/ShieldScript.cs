using UnityEngine;
using UnityEngine.UI;

public class ShieldScript : MonoBehaviour
{
    private bool touch;
    private GameObject touchObject;
    private float score;
    public Text scoreText;

    private void Start()
    {
        touch = false;
    }

    private void Update()
    {
        if (touch && (Input.GetKeyDown("x") || Input.GetKeyDown("z")))
        {
            var distanse = (transform.position-touchObject.transform.position).magnitude;
            score = distanse*100;
            scoreText.text = score.ToString("#.##");
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
