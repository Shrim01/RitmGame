using Unity.VisualScripting;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float timeLive;
    private float time;
    private float speed;
    void Start()
    {
        speed = GameObject.FindGameObjectWithTag("logic").GetComponent<ControlScript>().speedNote;
        var rot = Random.Range(0, 180) * Mathf.PI / 180;
        rb2D.velocity = new Vector2(Mathf.Cos(rot) * speed,
            Mathf.Sin(rot) * speed);
        Debug.Log(rot);
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeLive)
            Destroy(gameObject);
    }
}
