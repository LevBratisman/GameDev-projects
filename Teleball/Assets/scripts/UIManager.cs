using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Button level2;
    public Button level3;
    public Button level4;
    public int levelComplete;
    public bool volume = true;

    void Start() {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        level2.interactable = false;
        level3.interactable = false;
        level4.interactable = false;

        switch(levelComplete) {
            case 1:
                level2.interactable = true;
                break;
            case 2:
                level2.interactable = true;
                level3.interactable = true;
                break;
            case 3:
                level2.interactable = true;
                level3.interactable = true;
                level4.interactable = true;
                break;
            case 5:
                level2.interactable = true;
                level3.interactable = true;
                level4.interactable = true;
                break;
        }
    }

    public void Scenes(int numberScenes) {
        SceneManager.LoadScene(numberScenes);
    }

    public void Volume() {
        if (volume) {
            AudioListener.volume = 0;
            volume = false;
        } else if (!volume) {
            AudioListener.volume = 1;
            volume = true;
        }
    }

    public void Exit() {
        Application.Quit();
    }

}
