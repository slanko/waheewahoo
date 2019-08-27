using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dontkillmebro : MonoBehaviour
{
    public static dontkillmebro instance;
    public bool doTheThing = true;
    // Start is called before the first frame update
    void Start()
    {if(doTheThing == true)
        {
            if (instance == null)
            {
                instance = this;
            }
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(doTheThing == true)
        {
            if (SceneManager.GetActiveScene().name == "menu")
            {
                Destroy(gameObject);
            }
        }
    }

    void ClearDebris()
    {
        Destroy(gameObject);
    }
}
