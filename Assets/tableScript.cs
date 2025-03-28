using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using GamePlay.Script;

public class tableScript : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text percent;

    public void UpdateScore(int num)
    {
        score.text = Date.Records[num].ToString("Score: 0000000");
        percent.text = (Date.Records[num] * 1.0f / Date.MaxScore).ToString("#0.##%");
    }
}
