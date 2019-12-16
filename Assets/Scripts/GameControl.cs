using UnityEngine;
using TMPro;
using static MenuControl;
using static DotTypes;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public float scrollSpeed;
    public bool gameOver = false;
    private int score = 0;
    private AdvertHandler Advert;

    void Start()
    {
        Advert = gameObject.AddComponent<AdvertHandler>();
        ToggleMenu("GameOverMenu", Set.Inactive);
    }


    public void Score()
    {
        if (gameOver) return;
        score++;
        GameObject.Find("ScoreTMP").GetComponent<TextMeshProUGUI>().text = score.ToString(); 
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    

    public void GameOver()
    {
        gameOver = true;
        ToggleMenu("GameOverMenu", Set.Active);
        GameObject.Find("HighScoreTMP").GetComponent<TextMeshProUGUI>().text =
            "high score\n" + PlayerPrefs.GetInt("HighScore", 0);

        #if UNITY_ANDROID
            Advert.ShowAd(5);
        #endif
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
}
