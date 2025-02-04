using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collisionObj) {
        if(collisionObj.transform.CompareTag("Player")) {
            ///Destroy(collisionObj.gameObject); will not destroy the player    
            collisionObj.transform.GetComponent<PlayerRespawn>().playerDamage();
        }
    }
}
