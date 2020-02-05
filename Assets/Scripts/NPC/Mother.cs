using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour
{
    public LawnmowerMission mission;
    public bool missionCompleted;
    public GameObject hearts;

    // Update is called once per frame
    void Update()
    {
        missionCompleted = mission.missionSuccess;
        GetComponent<NPC>().isMissionComplete = true;

        if(missionCompleted)
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
