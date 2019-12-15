using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefsHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("HighScoreText").GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
