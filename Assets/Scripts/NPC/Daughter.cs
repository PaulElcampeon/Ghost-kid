﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daughter : MonoBehaviour
{
    public OpenDrawer mission;
    public bool missionCompleted;
    public int floorId;

    void Update()
    {
        if (!missionCompleted)
        {
            if (mission.missionSuccess)
            {
                missionCompleted = mission.missionSuccess;
                GetComponent<NPC>().isMissionComplete = true;
                GameManager.instance.CompleteAMission(floorId);

                if (missionCompleted)
                {
                    GetComponent<Animator>().SetBool("missionComplete", true);
                }
            }
        }
    }
}
