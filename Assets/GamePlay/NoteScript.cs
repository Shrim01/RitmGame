using UnityEngine;
using UnityEngine.Serialization;

public class NoteScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    private float speed = 2;
    private float timeLive = 4;
    private float time;

    void Start()
    {
        var rotation = GameObject.FindGameObjectWithTag("Center").transform.rotation.eulerAngles.z;
        var rotate = Random.Range(-90, 90);
        var rot = (rotation + rotate) / 180 * Mathf.PI;
        myRigidbody2D.velocity = new Vector2(Mathf.Cos(rot) * speed,
            Mathf.Sin(rot) * speed);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > timeLive)
            Destroy(gameObject);
    }
}
