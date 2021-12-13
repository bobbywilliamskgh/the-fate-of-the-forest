using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arch : enemy
{
    // Start is called before the first frame update
    
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    
    private Vector3 posisiku;
    public float xx,yy,zz;
    private Vector3 tujuPat;
    void Start()
    {
        posisiku = transform.position;
        target = GameObject.FindWithTag("Player").transform;
        tujuPat = new Vector3(xx, yy, zz);
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void patrol(){
        tujuPat = new Vector3(xx, yy, zz);
        transform.position = Vector3.MoveTowards(transform.position, posisiku,moveSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, tujuPat,moveSpeed * Time.deltaTime);
    }

    void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && 
        Vector3.Distance(target.position, transform.position) > attackRadius){
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else{
            //buatin patrol dong
            transform.position = Vector3.MoveTowards(transform.position, posisiku,moveSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, tujuPat,moveSpeed * Time.deltaTime);
        }

    }
    void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag.Equals("Player")){
            other.gameObject.GetComponent<PlayerHealthUpdate>().TakeDamage(baseAttack);
        }   
    }
}
