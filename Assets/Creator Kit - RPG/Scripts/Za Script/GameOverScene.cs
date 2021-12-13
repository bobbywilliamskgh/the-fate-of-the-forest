using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public Text teksku;
    public string levelling;
    private GameObject pemain;
    public void Setup(string masukan = "" ){
        Debug.Log("GameOverSetup");
        pemain = GameObject.FindGameObjectWithTag("Player");
        pemain.GetComponent<CharacterController2D>().enabled = false;
        teksku.text = masukan;
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        PlayerData.Restart = 1;
        SceneManager.LoadScene(levelling);
    }

    public void ExitButton(){
        SceneManager.LoadScene("Menu");
    }
}
