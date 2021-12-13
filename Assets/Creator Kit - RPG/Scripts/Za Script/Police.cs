using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : enemy
{
    // Start is called before the first frame update

    public Transform targetPlayer;
    public Transform targetPenebang;
    public float chaseRadius;
    public float attackRadius;

    private Vector3 posisiku;

    private int Darahku;
  
    void Start()
    {
        targetPlayer = GameObject.FindWithTag("Player").transform;
        targetPenebang = GameObject.Find("/Object/Penebang").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }


    public virtual void CheckDistance()
    {
        if (Vector3.Distance(targetPlayer.position, transform.position) <= chaseRadius &&
            Vector3.Distance(targetPlayer.position, transform.position) > attackRadius)
        {
                transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);
        }
        else if (Vector3.Distance(targetPenebang.position, transform.position) <= chaseRadius &&
            Vector3.Distance(targetPenebang.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPenebang.position, moveSpeed * Time.deltaTime);
        }

    }
    
    // biar kena damage kalau tabrakan
}
