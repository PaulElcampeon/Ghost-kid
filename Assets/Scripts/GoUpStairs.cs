using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUpStairs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CompareTag("Stairs"))
        {
            Debug.Log("Bob is here");
        }
    }
}
