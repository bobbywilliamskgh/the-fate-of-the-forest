using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPolice : Police
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    public override void CheckDistance()
    {
        // Cek jarak antara PatrolPolice dengan Player atau Penebang
        if ((Vector3.Distance(targetPlayer.position, transform.position) <= chaseRadius &&
            Vector3.Distance(targetPlayer.position, transform.position) > attackRadius) ||
            (Vector3.Distance(targetPenebang.position, transform.position) <= chaseRadius &&
            Vector3.Distance(targetPenebang.position, transform.position) > attackRadius))
        {
            if (Vector3.Distance(targetPenebang.position, transform.position) <= chaseRadius &&
            Vector3.Distance(targetPenebang.position, transform.position) > attackRadius)
            {
                // Bergerak ke arah penebang
                transform.position = Vector3.MoveTowards(transform.position, targetPenebang.position, moveSpeed * Time.deltaTime);
                //Debug.Log("Selisih x: " + Mathf.Abs(transform.position.x - targetPenebang.position.x));
                //Debug.Log("Selisih y: " + Mathf.Abs(transform.position.y - targetPenebang.position.y));
                if (Mathf.Abs(transform.position.x - targetPenebang.position.x) <= 1 && Mathf.Abs(transform.position.y - targetPenebang.position.y) <= 1)
                {
                    Debug.Log("Dekat Penebang");
                    this.gameObject.SetActive(false);
                }
               // Debug.Log("Posisi police: " + transform.position.x);
               // Debug.Log("Posisi penebang: " + targetPenebang.position.x);
            } else if (Vector3.Distance(targetPlayer.position, transform.position) <= chaseRadius &&
            Vector3.Distance(targetPlayer.position, transform.position) > attackRadius)
            {
                // Bergerak ke arah player
                transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);
            }
        }
        else if ((Vector3.Distance(targetPlayer.position, transform.position) > chaseRadius) || (Vector3.Distance(targetPenebang.position, transform.position) > chaseRadius))
        {
         
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
            } else
            {
                ChangeGoal();
            }
           
        }

        // Cek jarak antara PatrolPolice dengan Penebang
        /*
        if (Vector3.Distance(targetPenebang.position, transform.position) <= chaseRadius &&
            Vector3.Distance(targetPenebang.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPenebang.position, moveSpeed * Time.deltaTime);

        }
        else if (Vector3.Distance(targetPenebang.position, transform.position) > chaseRadius)
        {

            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
            }
            else
            {
                ChangeGoal();
            }

        }
        */
    }

    private void ChangeGoal()
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
