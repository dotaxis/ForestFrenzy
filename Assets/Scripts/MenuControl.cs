using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DotTypes;
using System.Runtime.InteropServices;



public class MenuControl : MonoBehaviour
{

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")] private static extern bool IsWebGLMobile();
#else
    bool IsWebGLMobile()
    {
        Debug.Log("Not WebGL");
        return false;
    }
#endif


    private string TutorialText;

    void Start()
    {
        Debug.Log("Mobile: " + IsWebGLMobile().ToString());
        if ((Application.platform == RuntimePlatform.WebGLPlayer && IsWebGLMobile())
            || Application.platform == RuntimePlatform.Android)
        {
            TutorialText = "tap left side to jump\n" +
                "tap right side to slide";
        } else {
            TutorialText = "left click to jump\n" +
                "right click to slide";
        }
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void LoadScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }


    public void ShowMainMenu()
    {
        ToggleMenu("MainMenu", Set.Active);
        ToggleMenu("OptionsMenu", Set.Inactive);
        ToggleMenu("TutorialMenu", Set.Inactive);
    }

    public void ShowOptionsMenu()
    {
        ToggleMenu("OptionsMenu", Set.Active);
        ToggleMenu("MainMenu", Set.Inactive);
        ToggleMenu("TutorialMenu", Set.Inactive);
    }

    public void ShowTutorialMenu()
    {
        ToggleMenu("TutorialMenu", Set.Active);
        GameObject.Find("TutorialTMP").GetComponent<TMPro.TextMeshProUGUI>().text = TutorialText;
        ToggleMenu("MainMenu", Set.Inactive);
        ToggleMenu("OptionsMenu", Set.Inactive);
    }

    public static void ToggleMenu(string menuName, Set toggle)
    {
        if (GameObject.Find(menuName))
        {
            foreach (Transform t in GameObject.Find(menuName).GetComponentsInChildren<Transform>(true))
            {
                if (t.gameObject.name != menuName)
                {
                    t.gameObject.SetActive(toggle.isActive() ? true : false);
                   //Debug.Log("Set " + t.gameObject.name + " to " + (toggle.isActive() ? "active" : "inactive"));
                }
            }
            Debug.Log("Set " + menuName + " to " + (toggle.isActive() ? "active" : "inactive"));
        } else {
            Debug.Log(menuName + " not found");
        }
    }
}
