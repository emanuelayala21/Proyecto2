using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager :MonoBehaviour {

    public GameObject optionsPanel; //panel for pause behavior

    public void OptionsPanel() {
        Time.timeScale = 0; //pause the time of the whole game 
        optionsPanel.SetActive(true);

    }

    public void Return() {
        Time.timeScale = 1;
        optionsPanel.SetActive(false); ///leave the pause 

    }
    
    public void MainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu"); // go to the menu scene
    }

    public void QuitGame() {
        Application.Quit();///close the app
    }
}
