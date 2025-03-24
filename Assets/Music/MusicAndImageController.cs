using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicAndImageController : MonoBehaviour
{
    public AudioSource audioSource; // Переменная для аудио
    public Image imageToShow; // Переменная для изображения

    void Start()
    {
        // Запускаем музыку
        audioSource.Play();
        // Запускаем корутину для показа изображения
        StartCoroutine(ShowImageAfterDelay(46f));
    }

    IEnumerator ShowImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Показываем изображение
        imageToShow.gameObject.SetActive(true);
    }
}