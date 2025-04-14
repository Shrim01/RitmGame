using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Script
{
    public class LogicScript : MonoBehaviour
    {
        public TMP_Text scoreText;
        public TMP_Text comboText;
        public GameObject progressBar;
        private int score = 0;
        private int combo = 0;
        private int maxCombo = 0;

        public void AddScore(float distanse)
        {
            if (distanse < 0.7f)
                score += 100 + combo++;
            else
            {
                if (combo > maxCombo)
                    maxCombo = combo;
                combo = 0;  
                score += 50;
            }
            UpdateScore();
        }

        public void EndSong()
        {
            if (score > Date.Records[4])
            {
                Date.Records[4] = score;
                Array.Sort(Date.Records, (a, b) => b.CompareTo(a));
            }

            Date.PreviousScore = score;
            Date.Combo = maxCombo;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
            SaveRecords();
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
