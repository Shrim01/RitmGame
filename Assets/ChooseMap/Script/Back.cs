using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Не забудь добавить это пространство имен для работы со сценами

public class Back : MonoBehaviour
{
    // Метод для перехода к сцене выбора карты
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Убедитесь, что имя сцены совпадает с вашим
    }

    public void Play()
    {
        SceneManager.LoadScene("GamePlay"); // Убедитесь, что имя сцены совпадает с вашим
    }

}
