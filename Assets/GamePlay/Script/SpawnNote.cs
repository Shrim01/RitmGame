using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;

public class SpawnNote : MonoBehaviour
{
    public GameObject note;
    public float timeSpawn;
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
