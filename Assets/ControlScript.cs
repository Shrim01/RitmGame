using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    public GameObject note;
    public float timeSpawn;
    public float speedNote;
    private float time;

    void Update()
    {
        SpawnNote();
        Rotate();
    }
    private void Rotate()
    {
        var position = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        var rotation = Mathf.Atan(position.y / position.x) * 180 / Mathf.PI;
        if (position.x < 0)
            rotation += 180;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    private void SpawnNote()
    {
        time += Time.deltaTime;
        if (time > timeSpawn)
        {
            Instantiate(note);
            time = 0;
        }
    }
}