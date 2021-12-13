using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeList : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] myTreeList = new GameObject[0];
    private int indexAttack;
    public GameOverScene gameOverScene;

    void Start()
    {
        myTreeList = GameObject.FindGameObjectsWithTag("PohonBawah");
        indexAttack = 0;
        // for (int i = 0; i < myTreeList.Length; i++)
        // {
        //     Debug.Log("myTreeList: " + myTreeList[i].name);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackTree(float damage, float posisiPenebang)
    {
        //Debug.Log("attack tree");
        //Debug.Log("getCurrentHealth " + myTreeList[indexAttack].GetComponent<TreeHealth>().GetCurrentHealth());
        if (indexAttack < myTreeList.Length)
        {
            //Debug.Log("jarak x penebang dan pohon : " + posisiPenebang - myTreeList[indexAttack].transform.position.x);
            if (myTreeList[indexAttack].GetComponent<TreeHealth>().GetCurrentHealth() > 0)
            {
                // Debug.Log("attack");
                myTreeList[indexAttack].GetComponent<TreeHealth>().TakeDamage(damage);

                // Jika nyawa pohon habis tepat setelah damage terakhir
                if (myTreeList[indexAttack].GetComponent<TreeHealth>().GetCurrentHealth() <= 0)
                {
                    // Debug.Log("rotasi z " + myTreeList[indexAttack].transform.rotation.z);
                    //myTreeList[indexAttack].transform.rotation = Quaternion.Euler(0, 0, 67);
                    myTreeList[indexAttack].GetComponent<TreeData>().ChangeSprite();
                    GameObject.Find("/Object/Penebang").GetComponent<penebang>().SetTriggered(false);
                    //index pohon selanjutnya
                    /*
                    Debug.Log("indeks " + indexAttack);
                    if (indexAttack < myTreeList.Length-1)
                    {
                        indexAttack++;
                    }
                    
                    Debug.Log("indeks next " + indexAttack);
                    */
                }
            }
            else
            {
                //Destroy(myTreeList[indexAttack].gameObject);
                //Debug.Log(myTreeList[indexAttack].transform.position);
                //indexAttack++;
            }
        }
        
    }

    public Vector3 GetTreePosition()
    {
        if (indexAttack+1 == myTreeList.Length)
        {
            return myTreeList[indexAttack].transform.position;
        } else
        {
            return myTreeList[indexAttack + 1].transform.position;
        }
    }

    public GameObject GetCurrentTree()
    {
        if (indexAttack + 1 == myTreeList.Length)
        {
            return myTreeList[indexAttack];
        }
        else
        {
            return myTreeList[indexAttack + 1];
        }
    }

    public float GetCurrentTreeHealth()
    {
        return myTreeList[indexAttack].GetComponent<TreeHealth>().GetCurrentHealth();
    }

    public void IncrementIndexAttack()
    {
        //Debug.Log("INDEX ATTCAK " + indexAttack);
        if (indexAttack < myTreeList.Length - 1)
        {
            indexAttack = indexAttack + 1;
        } else
        {
            //gameOverScene.Setup();
            //Debug.Log("game over " + gameOverScene);
            Debug.Log("GAME OVER");
            gameOverScene.Setup("Semua pohon habis ditebang");
        }
    }
}
