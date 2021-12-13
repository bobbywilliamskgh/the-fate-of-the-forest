using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthStart : MonoBehaviour
{
    public HealthBar healthBar;
    void Start()
    {
        PlayerData.maxHealth = 100;
        PlayerData.Healthku = PlayerData.maxHealth;
        healthBar.SetMaxHealth(PlayerData.maxHealth);
    }

    // Update is called once per frame
}
