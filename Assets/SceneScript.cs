using TMPro;
using UnityEngine;
using GamePlay.Script;
using UnityEngine.UI;

public class SceneScript : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text combo;
    public TMP_Text percent;

    private void Start()
    {
        score.text = Date.PreviousScore.ToString("0000000");
        combo.text = "X" + Date.Combo;
        percent.text = (Date.PreviousScore * 1.0f / Date.MaxScore).ToString("#0.##%");
    }

    public void ChooseScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChooseMap");
    }
}
