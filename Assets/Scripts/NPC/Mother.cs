using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : NPC
{
    public LawnmowerMission mission;
    public bool missionCompleted;
    public int floorId;

    public override void LateUpdate()
    {
        base.LateUpdate();

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
