using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuScript : MonoBehaviour
{
    public dontkillmebro[] dontKillScripts;
    public void loadGame()
    {
        SceneManager.LoadScene("gamescene");
        callClearDebris();
    }

    private void Start()
    {
        dontKillScripts = FindObjectsOfType(typeof(dontkillmebro)) as dontkillmebro[];
    }

    public void quitGame()
    {
        Application.Quit();
    }

    void callClearDebris()
    {
        dontKillScripts = FindObjectsOfType(typeof(dontkillmebro)) as dontkillmebro[];
            foreach(dontkillmebro go in dontKillScripts)
            {
                if(go.doTheThing == false)
                {
                    Destroy(go.gameObject);
                }
            }
    }
}
