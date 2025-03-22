using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using GamePlay.Script;

public class SceneScript : MonoBehaviour
{
    private AudioClip[] songs;

    private void Start()
    {
        songs = Resources.LoadAll<AudioClip>("");
    }

    public void ChooseScene(int numSong)
    {
        SceneManager.LoadScene(1);
        Date.Song = songs[numSong];
    }
}
