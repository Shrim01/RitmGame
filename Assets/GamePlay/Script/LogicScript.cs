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
                score += 200 + combo++;
            else
            {
                maxCombo = combo;
                combo = 0;
                score += 100;
            }
            UpdateScore();
        }

        public void EndSong()
        {
            //Тут будет переключение на экран с результатами
            if (score>Date.Records[4])
            {
                Date.Records[4] = score;
                Array.Sort(Date.Records, (a, b) => b.CompareTo(a));
            }
            Date.PreviousScore = score;
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

    }
}
