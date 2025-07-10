using UnityEngine;
using GamePlay.Script;

public class TableSpawner : MonoBehaviour
{
    public GameObject tablePrefab;
    public float spacing = 10f;
    private const int maxRecords = 5;

    void Start()
    {
        LoadRecords();
        SpawnTables();
    }

    private void SpawnTables()
    {
        var parentRectTransform = GetComponent<RectTransform>();
        int recordCount = 0;

        // Считаем реальное количество записей (ненулевых)
        for (int i = 0; i < maxRecords; i++)
        {
            if (Date.Records[i] > 0) recordCount++;
        }

        // Создаем таблицы для всех записей (включая нулевые)
        for (int i = 0; i < maxRecords; i++)
        {
            var position = new Vector3(0, -i * spacing, 0);
            var table = Instantiate(tablePrefab, parentRectTransform);
            table.GetComponent<RectTransform>().anchoredPosition = position;

            // Передаем индекс записи и флаг активности
            table.GetComponent<tableScript>().SetRecord(i, recordCount > i);
        }
    }

    private void LoadRecords()
    {
        var listJson = PlayerPrefs.GetString("SavedRecords");

        if (!string.IsNullOrEmpty(listJson))
        {
            Date.Records = JsonUtility.FromJson<SupportClass<int>>(listJson).Item;
        }
        else
        {
            Date.Records = new int[maxRecords];
        }
    }
}