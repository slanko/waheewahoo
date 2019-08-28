using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuScript : MonoBehaviour
{
    public dontkillmebro[] dontKillScripts;
    Animator anim;
    public void loadGame()
    {
        SceneManager.LoadScene("gamescene");
        callClearDebris();
    }

    private void Start()
    {
        dontKillScripts = FindObjectsOfType(typeof(dontkillmebro)) as dontkillmebro[];
        anim = GetComponent<Animator>();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void menuFlip()
    {
        anim.SetTrigger("switch");
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
