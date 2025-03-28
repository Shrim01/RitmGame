using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro; // �� ������ �������� ���� using ��� TextMesh Pro

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel; // ������ ���� �����
    public TMP_Text pauseText; // ����� "Esc - Pause" � �������������� TextMesh Pro
    private bool isPaused = false;
    public AudioSource musicSource; // ������ �� AudioSource ��� ������

    void Start()
    {
        pauseMenuPanel.SetActive(false); // �������� ���� ����� � ������
        pauseText.gameObject.SetActive(true); // ���������� �����
        Invoke("HidePauseText", 4f);
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
        Time.timeScale = 0; // ������������� �����
        musicSource.Pause(); // ���������������� ������
        pauseMenuPanel.SetActive(true); // ���������� ���� �����
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // ���������� �����
        musicSource.UnPause(); // ������������ ������
        pauseMenuPanel.SetActive(false); // �������� ���� �����
    }

    void HidePauseText()
    {
        pauseText.gameObject.SetActive(false); // �������� �����
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // ���������� �����
        // ����� �������� ������ ��� ����������� ������
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        // ����� �������� ������ ��� ������ � ������� ����
        // ��������, �������� �������� ����
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChooseMap"); // �������� �� ��� ����� ����� �������� ����
    }
}