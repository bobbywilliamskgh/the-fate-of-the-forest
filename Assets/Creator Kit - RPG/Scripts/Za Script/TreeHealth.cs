using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            //Debug.Log("nyawa pohon abis");
        } else
        {
            Debug.Log("nyawa pohon belum abis : " + currentHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
