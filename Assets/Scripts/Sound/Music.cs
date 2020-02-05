using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music _instance;

    void Awake()
    {
        if(_instance == null)
    {
        _instance = this;
        DontDestroyOnLoad(_instance);
    }
        else
        {
            Destroy(gameObject);
        }
    }

  

  
}
