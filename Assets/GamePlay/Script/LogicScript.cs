using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Script
{
    public class LogicScript : MonoBehaviour
    {
        public Text scoreText;
        public Text comboText;
        private int score = 0;
        private int combo = 0;
        private int maxCombo = 0;

        public void AddScore(float distanse)
        {
            if (distanse < 0.3f)
            {
                combo++;
                score += 100;
            }
            else
            {
                maxCombo = combo;
                combo = 0;
                score += 50;
            }
            UpdateScore();
        }

        private void UpdateScore()
        {
            scoreText.text = score.ToString();
            comboText.text = "X" + combo;
        }
    }
}
