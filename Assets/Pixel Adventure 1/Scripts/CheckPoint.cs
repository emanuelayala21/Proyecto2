using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint :MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collisionObj) {
        if(collisionObj.CompareTag("Player")) {
            collisionObj.GetComponent<PlayerRespawn>().CheckPointReached(
                collisionObj.transform.position.x, 
                collisionObj.transform.position.y,
                SceneManager.GetActiveScene().buildIndex
            );

            GetComponent<Animator>().enabled = true; 
        }
    }
}
