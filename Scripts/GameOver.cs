using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private float gameOverTimer;

	void Start () {

        gameOverTimer = 0;

	}
	
	void Update () {

        gameOverTimer += Time.deltaTime;

        if(gameOverTimer > 5)
        {
            SceneManager.LoadScene("StartScreen");
        }
		
	}
}
