using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;

namespace GamePlay.Script
{
    public class LogicScript : MonoBehaviour
    {
        public TMP_Text scoreText;
        public TMP_Text comboText;
        public GameObject progressBar;
        public AudioSource audioSource;
        public AudioClip missSound;

        // ����������� ���� (�����)
        [Header("Effects")] public GameObject score100Prefab;
        public GameObject score50Prefab;
        public GameObject missXPrefab;
        public List<GameObject> starPrefabs = new List<GameObject>();

        [Header("References")] public Transform shieldTransform;
        private GameObject currentEffect;
        private int score = 0;
        private int combo = 0;
        private int maxCombo = 0;
        private bool visualEffectsEnabled = true; // ���� ��������� ���������� �������� (���������)
        // Добавляем константу для максимального количества записей
        private const int maxRecords = 5;

        private void Awake()
        {
            visualEffectsEnabled = PlayerPrefs.GetInt("VisualEffectsEnabled", 1) == 1;
            if (shieldTransform == null)
            {
                var shield = GameObject.FindGameObjectWithTag("Shield");
                if (shield)
                    shieldTransform = shield.transform;
            }
        }

        // �������� ����� ���������� ����� (�������������)
        public void AddScore(float distance)
        {
            if (distance < 0.7f)
            {
                score += 100 + combo++;
                ShowScoreEffect(score100Prefab);
                CreateStars();
            }
            else if (distance < 2.6f)
            {
                if (combo > maxCombo)
                    maxCombo = combo;
                combo = 0;
                score += 50;
                ShowScoreEffect(score50Prefab);
            }
            else
                ShowMissEffect();

            UpdateScore(); // �������� �����
        }

        public void EffectSpinner(int countRotate, bool isEnd)
        {
            Debug.Log(countRotate);
            //МЕСТО ДЛЯ АНИМАЦИИ ИЗМЕНЕНИЯ ИКСОВ   
            if (isEnd)
            {
                score += (countRotate * 100);
                UpdateScore();
            }
        }

        // ���������: ����� ��� ����������� ������� �������
        public void ShowMissEffect()
        {
            ReplaceEffect(missXPrefab);
            if (audioSource != null && missSound != null)
            {
                audioSource.PlayOneShot(missSound);
            }
        }

        private void ShowScoreEffect(GameObject prefab)
        {
            ReplaceEffect(prefab);
        }

        private void ReplaceEffect(GameObject newEffectPrefab)
        {
            if (currentEffect != null)
            {
                Destroy(currentEffect);
            }

            var center = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
            currentEffect = Instantiate(newEffectPrefab, center, Quaternion.identity);

            StartCoroutine(DestroyAfterDelay(currentEffect, 0.5f));
        }
        private IEnumerator DestroyAfterDelay(GameObject effect, float delay)
        {
            yield return new WaitForSeconds(delay);
            if (effect != null)
            {
                Destroy(effect);
            }
        }

        // ���������: ��������� ��������� ������ (���������� ����������)
        public void SetVolume(float volume)
        {
            if (audioSource != null)
            {
                audioSource.volume = volume;
            }
        }
        public void SetVisualEffectsEnabled(bool enabled)
        {
            visualEffectsEnabled = enabled;
        }
        
        private void CreateStars()
        {
            if (!visualEffectsEnabled) return; // �������� �����

            if (shieldTransform == null) return;

            var starCount = UnityEngine.Random.Range(1, 12);
            var shieldPos = shieldTransform.position;

            for (int i = 0; i < starCount; i++)
            {
                if (starPrefabs.Count == 0) break;

                GameObject starPrefab = starPrefabs[UnityEngine.Random.Range(0, starPrefabs.Count)];
                GameObject star = Instantiate(starPrefab, shieldPos, Quaternion.identity);
                star.AddComponent<StarEffect>();
            }
        }

        public void EndSong()
        {
            if (combo > maxCombo)
                maxCombo = combo;

            LoadRecords();
            UpdateRecords(score);

            Date.PreviousScore = score;
            Date.Combo = maxCombo;
            SaveRecords();
            SceneManager.LoadScene("Result");
        }

        private void UpdateRecords(int newScore)
        {
            // Создаем временный список для всех записей
            var recordsList = Date.Records.ToList();

            // Добавляем новый результат
            recordsList.Add(newScore);

            // Сортируем по убыванию и берем топ-5
            recordsList = recordsList
                .OrderByDescending(r => r)
                .Take(maxRecords)
                .ToList();

            // Дополняем нулями если нужно
            while (recordsList.Count < maxRecords)
            {
                recordsList.Add(0);
            }

            Date.Records = recordsList.ToArray();
        }

        // �������� ����� ���������� ��������-���� (��� ���������)
        public void UpdateProgressBar(float value)
        {
            if (progressBar != null)
            {
                Slider slider = progressBar.GetComponent<Slider>();
                if (slider != null)
                {
                    slider.value = value;
                }
            }
        }

        // �������� ����� ���������� UI ����� (��� ���������)
        private void UpdateScore()
        {
            if (scoreText != null)
                scoreText.text = score.ToString("0000000");

            if (comboText != null)
                comboText.text = "X" + combo;
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

        private void SaveRecords()
        {
            var listJson = JsonUtility.ToJson(new SupportClass<int>(Date.Records), true);
            PlayerPrefs.SetString("SavedRecords", listJson);
            PlayerPrefs.Save();
        }
    }
}