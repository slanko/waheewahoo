using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuScript : MonoBehaviour
{
    public dontkillmebro[] dontKillScripts;
    Animator anim;
    public GameObject scoreBoardMen;
    Animator anim2;
    bool debrisCheck = false;
    public void loadGame()
    {
        SceneManager.LoadScene("gamescene");
        callClearDebris();
    }

    private void Start()
    {
        dontKillScripts = FindObjectsOfType(typeof(dontkillmebro)) as dontkillmebro[];

        anim = GetComponent<Animator>();

        anim2 = scoreBoardMen.GetComponent<Animator>();

        if (dontKillScripts.Length >= 1)
        {
            anim2.SetBool("debrisInScene", true);
        }
        else
        {
            anim2.SetBool("debrisInScene", false);
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void menuFlip()
    {
        anim.SetTrigger("switch");
    }

    public void toggleDebrisChecker()
    {

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
