using System;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.OnGameOver += GM_OnGameOver;
        Hide();
    }

    private void GM_OnGameOver(object sender, EventArgs e)
    {
        Show();
    }

    private void Hide() => gameObject.SetActive(false);
    private void Show() => gameObject.SetActive(true);
}
