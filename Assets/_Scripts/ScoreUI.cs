using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "0";
        GameManager.Instance.OnScoreChange += GM_OnScoreChange;
    }

    private void GM_OnScoreChange(object sender, EventArgs e)
    {
        scoreText.text = GameManager.Instance.GetScore().ToString();
    }
}
