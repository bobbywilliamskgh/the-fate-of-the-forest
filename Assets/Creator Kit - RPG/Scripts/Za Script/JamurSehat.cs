using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamurSehat : MonoBehaviour
{
    public float darah_jamur;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Player")){
            other.gameObject.GetComponent<PlayerHealthUpdate>().Healing(darah_jamur);
            this.gameObject.SetActive(false);
        }    
    }
}
