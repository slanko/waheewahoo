﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuScript : MonoBehaviour
{

    public void loadGame()
    {
        SceneManager.LoadScene("gamescene");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
