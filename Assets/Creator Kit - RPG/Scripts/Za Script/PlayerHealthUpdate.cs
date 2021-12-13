using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUpdate : MonoBehaviour
{
    public HealthBar healthBar;
    public GameOverScene gameOverScene;
    // Update is called once per frame
    void Start(){
        if(PlayerData.Restart == 0){
            if(PlayerData.maxHealth == 0){ healthBar.SetMaxHealth(100);}
            else{healthBar.SetHealth(PlayerData.Healthku); }
        }
        else{
            healthBar.SetMaxHealth(100);
        }
    }
    void Update(){
        if(PlayerData.Healthku <= 0){
            gameOverScene.Setup("Anda tertangkap");
        }
    }

    public void TakeDamage(float damage){
        PlayerData.Healthku -= damage;
        healthBar.SetHealth(PlayerData.Healthku);
    }

    public void Healing(float heal){
        PlayerData.Healthku += heal;
        if(PlayerData.Healthku > PlayerData.maxHealth){
            PlayerData.Healthku = PlayerData.maxHealth;}
        healthBar.SetHealth(PlayerData.Healthku);
    }
}
