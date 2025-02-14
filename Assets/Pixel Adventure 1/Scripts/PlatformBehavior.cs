using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior :MonoBehaviour {

    private PlatformEffector2D effector;
    [SerializeField]
    private float startWaitTime;
    [SerializeField]
    private float waitedTime;
    void Start() {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update() {
        if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s")) {
            waitedTime = startWaitTime;
        }

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s")) {
            if(waitedTime <= 0) {
                effector.rotationalOffset = 180;
                waitedTime = startWaitTime;
            } else {
                waitedTime -= Time.deltaTime;
            }
        }

        if(Input.GetKey("space")) {
            effector.rotationalOffset = 0;
        }
    }
}