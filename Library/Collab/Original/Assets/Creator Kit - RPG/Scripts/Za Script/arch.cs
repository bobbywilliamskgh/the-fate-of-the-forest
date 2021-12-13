using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arch : enemy
{
    // Start is called before the first frame update

    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }
    public virtual void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && 
        Vector3.Distance(target.position, transform.position) > attackRadius){
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        }
    }
}