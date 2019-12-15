using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DotTypes;

public class MenuControl : MonoBehaviour
{

    public void LoadScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }


    public void ShowMainMenu()
    {
        ToggleMenu("MainMenu", Set.Active);
        ToggleMenu("OptionsMenu", Set.Inactive);
        ToggleMenu("StatsMenu", Set.Inactive);
    }

    public void ShowOptionsMenu()
    {
        ToggleMenu("OptionsMenu", Set.Active);
        ToggleMenu("MainMenu", Set.Inactive);
        ToggleMenu("StatsMenu", Set.Inactive);
    }

    public void ShowStatsMenu()
    {
        ToggleMenu("StatsMenu", Set.Active);
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
