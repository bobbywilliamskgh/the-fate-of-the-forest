using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awan : MonoBehaviour
{
    public void Setup()
    {
        Debug.Log("Awan Setup");
        gameObject.SetActive(true);
    }

    public void ChangePosition(Vector3 posisi)
    {
        Debug.Log("posisi awan berubah");
        transform.position = posisi;
    }
}
