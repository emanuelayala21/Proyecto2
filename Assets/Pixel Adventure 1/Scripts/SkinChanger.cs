using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger :MonoBehaviour {

    public GameObject skinPanel;
    private bool inDoor = false;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            skinPanel.gameObject.SetActive(true);
            inDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            skinPanel.gameObject.SetActive(false);
            inDoor = false;
        }
    }
    public void SetPlayerFrog() {
        PlayerPrefs.SetString("PlayerSelected", "NinjaFrog");
        resetPlayerSkin();
    }
    public void SetPlayerPinkMan() {
        PlayerPrefs.SetString("PlayerSelected", "PinkMan");
        resetPlayerSkin();
    }
    public void SetPlayerMaskDude() {
        PlayerPrefs.SetString("PlayerSelected", "MaskDude");
        resetPlayerSkin();
    }
    private void resetPlayerSkin() {
        skinPanel.gameObject.SetActive(false);
        player.GetComponent<PlayerSelected>().changePlayerInMenu();
    }
}
