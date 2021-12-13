using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    public string enemyName;
    public float baseAttack;
    public float moveSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerHealthUpdate>().TakeDamage(baseAttack);
        }
    }
}
