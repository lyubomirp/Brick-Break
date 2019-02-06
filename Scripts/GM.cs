using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    public int lives = 3;
    public int bricks = 40;
    public float resetDelay = 1f;
    public Text LivesText;
    public GameObject GameOver;
    public GameObject YouWon;
    public static GameObject weakCube;
    public static GameObject middleCubeBlue;
    public static GameObject middleCubeOrange;
    public static GameObject strongCube;
    public GameObject paddle;
    public GameObject deathParticles;
    public Text Score;
    public int score = 0;
    public static GM instance = null;

    public GameObject[] cubes = new GameObject[] { weakCube, middleCubeBlue, middleCubeOrange, strongCube,
        weakCube, weakCube, weakCube, weakCube, weakCube };

    private GameObject clonePaddle;
	
	void Start () {
		if(instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
        Setup();
	}

    private void Update()
    {
        Score.text = "Score: " + score;
    }

    private void Setup()
    {
        System.Random rand = new System.Random();
        float x = -14f;
        float y = 9f;
        clonePaddle = Instantiate(paddle, transform.position, paddle.transform.rotation) as GameObject;
        for (int i = 0; i < bricks; i++)
        {
            int randomNum = rand.Next(0, 9);
            if (x >= 15)
            {
                y -= 2;
                x = -14;
            }
            Instantiate(cubes[randomNum], new Vector3(x,y,0), Quaternion.identity);
            x += 3;
            
        }
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            YouWon.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("ResetGame", resetDelay);
        }

        if (lives < 1)
        {
            GameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("ResetGame", resetDelay);
        }
    }


    private void ResetGame()
    {
       Time.timeScale = 1f;
       SceneManager.LoadScene(0);
    }

    public void LoseLife()
    {
        lives--;
        Destroy(clonePaddle);
        LivesText.text = "Lives: "+lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    private void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, paddle.transform.rotation) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }
}
