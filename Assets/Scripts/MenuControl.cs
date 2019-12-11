using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("HighScoreText").GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("pressed mouse button");
            SceneManager.LoadScene("GameScene");
        } else if (Input.GetMouseButtonUp(1))
        {
            //PlayerPrefs.DeleteAll();
        }
    }
}
