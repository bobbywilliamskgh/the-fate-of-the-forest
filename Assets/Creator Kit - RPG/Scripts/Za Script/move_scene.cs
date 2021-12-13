using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move_scene : MonoBehaviour
{
    // Start is called before the first frame update
    public string scenetoload;
    public GameObject[] musuhku;


    void Update() {
        musuhku = GameObject.FindGameObjectsWithTag("Enemy");    
    }

    void OnTriggerEnter2D(Collider2D other){
        if(musuhku.Length == 0){
            if(other.CompareTag("Player")){
                SceneManager.LoadScene(scenetoload,LoadSceneMode.Single);
            }
            Debug.Log("Habislah Musuhnya");
        }
    }
}
