using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro; // Не забудь добавить этот using для TextMesh Pro

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Панель меню паузы
    public TMP_Text pauseText; // Текст "Esc - Pause" с использованием TextMesh Pro
    private bool isPaused = false;
    public AudioSource musicSource; // Ссылка на AudioSource для музыки

    void Start()
    {
        pauseMenuPanel.SetActive(false); // Скрываем меню паузы в начале
        pauseText.gameObject.SetActive(true); // Показываем текст
        Invoke("HidePauseText", 4f); // Скрываем текст через 4 секунды
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // Останавливаем время
        musicSource.Pause(); // Приостанавливаем музыку
        pauseMenuPanel.SetActive(true); // Показываем меню паузы
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Возвращаем время
        musicSource.UnPause(); // Возобновляем музыку
        pauseMenuPanel.SetActive(false); // Скрываем меню паузы
    }

    void HidePauseText()
    {
        pauseText.gameObject.SetActive(false); // Скрываем текст
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Возвращаем время
        // Здесь добавьте логику для перезапуска уровня
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        // Здесь добавьте логику для выхода в главное меню
        // Например, загрузка главного меню
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChooseMap"); // Замените на имя вашей сцены главного меню
    }
}