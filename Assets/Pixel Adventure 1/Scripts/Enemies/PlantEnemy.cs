using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy :MonoBehaviour {

    public float waitedTime;
    public float fireRate = 3f;
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform launchSpawnPoint;

    void Start() {
        waitedTime = fireRate;
    }

    void Update() {
        if(waitedTime <= 0) {
            waitedTime = fireRate;
            animator.Play("attack");
            Invoke("LauchBullet", 0.5f);

        } else {
            waitedTime -= Time.deltaTime;
        }
    }
    void LauchBullet() {
        GameObject newBullet;  
        newBullet = Instantiate(bulletPrefab , launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
