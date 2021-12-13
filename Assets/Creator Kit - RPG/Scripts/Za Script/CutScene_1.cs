using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene_1 : MonoBehaviour
{
    public string sceneku;
    void OnEnable() {
        SceneManager.LoadScene(sceneku, LoadSceneMode.Single);    
    }
}
