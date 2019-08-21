using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontkillmebro : MonoBehaviour
{
    public static dontkillmebro instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    }
}
