using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Image lifeBar;

    private void Start()
    {
        player.OnHealthChange += Player_OnHealthChange;
    }

    private void Player_OnHealthChange(object sender, EventArgs e)
    {
        lifeBar.fillAmount = player.playerHealth / player.maxPlayerHealth;
    }
}
