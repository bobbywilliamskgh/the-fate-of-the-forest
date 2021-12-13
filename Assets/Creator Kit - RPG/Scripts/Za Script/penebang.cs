using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class penebang : enemy
{
    // Start is called before the first frame update

    public Transform targetPlayer;
    public Transform targetPolice;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private bool triggered;
    private float cutTree;
    public Awan awan;
    //public Sprite newSprite;

    void Start()
    {
        cutTree = 0.1f;
        triggered = true;
        targetPlayer = GameObject.FindWithTag("Player").transform;
        targetPolice = GameObject.Find("/Object/Patrol Police").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        if (triggered)
        {
            //Debug.Log("TRIGEEREDDDD TRUEEEE");
            GameObject.Find("/Tree Collection/ArrayHandler").GetComponent<TreeList>().AttackTree(cutTree, transform.position.x);
        }
    }

    void CheckDistance()
    {
        if (Mathf.Abs(transform.position.x - targetPolice.position.x) <= 1 && Mathf.Abs(transform.position.y - targetPolice.position.y) <= 1)
        {
            Debug.Log("Dekat Police");
            //gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            //Thread.Sleep(2000);
            awan.Setup();
            awan.ChangePosition(transform.position);
            this.gameObject.SetActive(false);



        }
        if (Vector3.Distance(targetPlayer.position, transform.position) <= chaseRadius &&
        Vector3.Distance(targetPlayer.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);
            
        } else
        {
            //Debug.Log("CurrentTreeHealth " + GameObject.Find("/Animated Tree1 Collection/ArrayHandler").GetComponent<TreeList>().GetCurrentTreeHealth());
            if (GameObject.Find("/Tree Collection/ArrayHandler").GetComponent<TreeList>().GetCurrentTreeHealth() <= 0)
            {
                //Debug.Log("Move to next tree");
                MoveToTree();
                
            }
            
        }
    }

    // Bergerak ke pohon selanjutnya
    public void MoveToTree()
    {
        Vector3 nextTreePosition = GameObject.Find("/Tree Collection/ArrayHandler").GetComponent<TreeList>().GetTreePosition();
        //Debug.Log("posisi penebang " + transform.position);
        //Debug.Log("posisi tree " + nextTreePosition);
        transform.position = Vector3.MoveTowards(transform.position, nextTreePosition, moveSpeed * Time.deltaTime);
        //Debug.Log("posisi penebang " + transform.position);
        //Debug.Log("posisi tree " + nextTreePosition);
        if (Vector3.Distance(transform.position, nextTreePosition) < 0.1f)
        {
            triggered = true;
            //Debug.Log("posisi penebang dan pohon sama");
            //Debug.Log("INCREMENT INDEX ATTACK");
            GameObject.Find("/Tree Collection/ArrayHandler").GetComponent<TreeList>().IncrementIndexAttack();
        }
        //GameObject.Find("/Animated Tree1 Collection/ArrayHandler").GetComponent<TreeList>().IncrementIndexAttack();
        //Debug.Log("increment index attack");
        //Debug.Log("posisi next tree: " + treePosition);
    }

    public void SetTriggered(bool trg)
    {
        triggered = trg;
    }
    
}
