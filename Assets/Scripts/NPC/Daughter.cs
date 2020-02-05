using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daughter : MonoBehaviour
{
    public OpenDrawer mission;
    public bool missionCompleted;
    public GameObject hearts;
    public int floorId;

    void Update()
    {
        if (!missionCompleted)
        {
            missionCompleted = mission.missionSuccess;
            GetComponent<NPC>().isMissionComplete = true;
            GameManager.instance.CompleteAMission(floorId);

            if (missionCompleted)
            {
                GetComponent<Animator>().SetBool("isRunning", false);
                GetComponent<Animator>().SetBool("isWaiting", false);
                GetComponent<Animator>().SetBool("isWaitingInFear", false);
                GetComponent<Animator>().SetBool("checkOutSound", false);
                GetComponent<Animator>().SetBool("isShocked", false);
                GetComponent<Animator>().SetBool("isWalking", false);

                GetComponent<Animator>().SetBool("missionComplete", true);
                //hearts.SetActive(true);
            }
        }
    }
}
