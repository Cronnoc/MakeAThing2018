using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Scene GameScene;

    GameObject TitleObject, MainObject, CreditsObject;


	// Use this for initialization
	void Start () {
        TitleObject = GameObject.Find("Title screen");
        MainObject = GameObject.Find("Main Menu");
        CreditsObject = GameObject.Find("Credits");
        Debug.Log("Menu Objects Found");
        TitleScreen();
	}

	public void ClearScreen()
    {
        TitleObject.SetActive(false);
        MainObject.SetActive(false);
        CreditsObject.SetActive(false);
    }

    public void TitleScreen()
    {
        ClearScreen();
        TitleObject.SetActive(true);
        Debug.Log("Title Screen");
    }

    public void MainMenuScreen()
    {
        ClearScreen();
        MainObject.SetActive(true);
        Debug.Log("Main Menu Screen");
    }

    public void CreditsScreen()
    {
        ClearScreen();
        CreditsObject.SetActive(true);
        Debug.Log("Credits Screen");
    }

    public void Play()
    {
        SceneManager.LoadScene(GameScene.name);
    }
}
