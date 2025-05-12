using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

namespace GamePlay.Script
{
    public class LogicScript : MonoBehaviour
    {
        public static LogicScript Instance;
        
        [Header("Audio")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip missSound;

        [Header("UI Elements")]
        public TMP_Text scoreText;
        public TMP_Text comboText;
        public GameObject progressBar;

        [Header("Effects")]
        public GameObject score100Prefab;
        public GameObject score50Prefab;
        public GameObject missXPrefab;
        public List<GameObject> starPrefabs = new List<GameObject>();

        private GameObject currentEffect;
        private int score = 0;
        private int combo = 0;
        private int maxCombo = 0;

        private void Awake()
        {
            Instance = this;
        }

        public void AddScore(float distance)
        {
            if (distance < 0.7f)
            {
                score += 100 + combo++;
                ShowScoreEffect(score100Prefab);
                CreateStars();
            }
            else
            {
                if (combo > maxCombo)
                    maxCombo = combo;
                combo = 0;
                score += 50;
                ShowScoreEffect(score50Prefab);
            }
            UpdateScore();
        }

        public void ShowMissEffect()
        {
            ReplaceEffect(missXPrefab);

            // ������������� ����
            if (audioSource != null && missSound != null)
            {
                audioSource.PlayOneShot(missSound);
            }
        }

        private void ShowScoreEffect(GameObject prefab)
        {
            ReplaceEffect(prefab);
        }

        // ������������� ����� ��� ������ ��������
        private void ReplaceEffect(GameObject newEffectPrefab)
        {
            // ������� ���������� ������, ���� �� ����
            if (currentEffect != null)
            {
                Destroy(currentEffect);
            }

            // ������� ����� ������
            var center = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
            currentEffect = Instantiate(newEffectPrefab, center, Quaternion.identity);

            // �������������� �������� ����� 0.5 ��� (������� ����� �� �������)
            StartCoroutine(DestroyAfterDelay(currentEffect, 0.5f));
        }

        // �������� ��� �������� �������
        private IEnumerator DestroyAfterDelay(GameObject effect, float delay)
        {
            yield return new WaitForSeconds(delay);
            if (effect != null)
            {
                Destroy(effect);
            }
        }

        private void CreateStars()
        {
            int starCount = UnityEngine.Random.Range(3, 12);
            Vector3 shieldPos = GameObject.FindGameObjectWithTag("Shield").transform.position;

            for (int i = 0; i < starCount; i++)
            {
                GameObject starPrefab = starPrefabs[UnityEngine.Random.Range(0, starPrefabs.Count)];
                GameObject star = Instantiate(starPrefab, shieldPos, Quaternion.identity);
                star.AddComponent<StarEffect>();
            }
        }

        public void EndSong()
        {
            if (combo > maxCombo)
                maxCombo = combo;
            if (score > Date.Records[4])
            {
                Date.Records[4] = score;
                Array.Sort(Date.Records, (a, b) => b.CompareTo(a));
            }

            Date.PreviousScore = score;
            Date.Combo = maxCombo;
            SaveRecords();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
        }

        public void UpdateProgressBar(float value)
        {
            progressBar.GetComponent<Slider>().value = value;
        }

        private void UpdateScore()
        {
            scoreText.text = score.ToString("0000000");
            comboText.text = "X" + combo;
        }

        private void SaveRecords()
        {
            var listJson = JsonUtility.ToJson(new SupportClass<int>(Date.Records), true);
            PlayerPrefs.SetString("SavedRecords", listJson);
        }
    }
}
