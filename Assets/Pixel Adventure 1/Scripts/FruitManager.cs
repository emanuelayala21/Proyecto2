using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitManager :MonoBehaviour {
    public Text text;
    public int total;
    void Start() {
        total = gameObject.transform.childCount;
        fruitCount();
    }

    void Update() {
        fruitCount();
    }
    private void fruitCount() {
        //count fruits on screen
        int count = gameObject.transform.childCount;
        text.text = "Score: " + (total - count) + "/" + total;
    }
}
