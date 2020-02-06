using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnmowerMission : MonoBehaviour
{
    public bool missionSuccess = false;
    public bool isGassed;
    
    void Update()
    {
        if (transform.position.x < 27 && isGassed)
        {
            missionSuccess = true;
        }
    }
}
