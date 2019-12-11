using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    public float scrollSpeed = -2f;
    public bool gameOver = false;

    private int score = 0;

    public void Score()
    {
        if (gameOver) return;
        score++;
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + score.ToString(); 
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void GameOver()
    {
        GameObject.Find("GameOver").GetComponent<Text>().enabled = true;
        gameOver = true;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
