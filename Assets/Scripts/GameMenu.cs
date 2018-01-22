using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    int lives;
    GameObject GameController;

	// Use this for initialization
	void Start () {

        LoadLevel( PlayerPrefs.GetInt("Level"), PlayerPrefs.GetInt("Lives"));
        GameController = GameObject.FindGameObjectWithTag("GameController");

    }
	
    void LoadLevel(int Level, int Lives)
    {
        //pars the vars to game controller scpt 
    }

   public void EndLevel()
    {
        PlayerPrefs.SetInt("Level", (PlayerPrefs.GetInt("Level")+1));
        PlayerPrefs.SetInt("Lives", lives);
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }
}
