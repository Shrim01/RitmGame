using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableSpawner : MonoBehaviour
{
    public GameObject tablePrefab; // Префаб table
    public int numberOfTables = 5; // Количество префабов
    public float spacing = 10f; // Расстояние между префабами

    void Start()
    {
        SpawnTables();
    }

    void SpawnTables()
    {
        // Получаем RectTransform текущего объекта
        RectTransform parentRectTransform = GetComponent<RectTransform>();

        for (int i = 0; i < numberOfTables; i++)
        {
            // Рассчитываем позицию для каждого префаба
            Vector3 position = new Vector3(0, -i * spacing, 0); // Обратите внимание на знак минус, чтобы разместить вниз
            GameObject tableInstance = Instantiate(tablePrefab, parentRectTransform);
            tableInstance.GetComponent<RectTransform>().anchoredPosition = position; // Устанавливаем позицию
        }
    }
}