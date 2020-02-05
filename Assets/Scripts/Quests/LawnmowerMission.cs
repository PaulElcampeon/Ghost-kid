using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnmowerMission : MonoBehaviour
{
    public bool missionSuccess = false;
    
    void Update()
    {
        if (transform.position.x < 27)
        {
            missionSuccess = true;
        }
    }
}
