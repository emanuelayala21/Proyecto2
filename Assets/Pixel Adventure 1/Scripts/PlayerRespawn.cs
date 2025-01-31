using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn :MonoBehaviour {
    void Start() {
        if(PlayerPrefs.GetInt("checkPScene") == SceneManager.GetActiveScene().buildIndex) {
            if(PlayerPrefs.GetFloat("checkPX") != 0 && PlayerPrefs.GetFloat("checkPY") != 0) {
                transform.position = new Vector2(PlayerPrefs.GetFloat("checkPX"), PlayerPrefs.GetFloat("checkPY"));
            }
        }
    }

    public void CheckPointReached(float x, float y, int scene) {

        PlayerPrefs.SetFloat("checkPX", x);
        PlayerPrefs.SetFloat("checkPY", y);
        PlayerPrefs.SetInt("checkPScene", scene);
    }

}
