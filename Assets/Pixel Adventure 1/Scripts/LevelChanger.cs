using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger :MonoBehaviour {

    public Text text;
    public string levelName;
    public string levelText;
    private bool inDoor = false;
    void Start() {

    }

    void Update() {
        if(inDoor && Input.GetKey("x")) {
            SceneManager.LoadScene(levelName);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {

            text.text = "Presione X para ingrear a " + levelText;
            text.gameObject.SetActive(true);
            inDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {

            text.text = "Presione X para ingrear a " + levelText;
            text.gameObject.SetActive(false);
            inDoor = false;
        }
    }
}
