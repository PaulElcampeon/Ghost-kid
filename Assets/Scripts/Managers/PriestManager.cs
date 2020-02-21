using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestManager : MonoBehaviour
{
    public GameObject[] priests;

    public float leftSideOfHouseXPos;
    public float rightSideOfHouseXPos;
    public float middleOfHouseXPos;
    public AudioSource[] bgm;

    public static PriestManager instance;

    void Start()
    {
        instance = this;
    }

    public void Spawn()
    {
        SoundEngine.instance.PlayPriestMusic(bgm, 2f, 0.7f);
        List<int> availableFloors = GetAllAvailableFloors();
        int randomFloor = availableFloors[Random.Range(0, availableFloors.Count)];
        GivePriestSpawnPoint(priests[randomFloor]);
        priests[randomFloor].SetActive(true);
    }

    public List<int> GetAllAvailableFloors()
    {
        List<int> availableFloors = new List<int>();

        foreach(Floor floor in GameManager.instance.floors)
        {
            if(!floor.isMissionComplete)
            {
                availableFloors.Add(floor.floorId);
            }
        }
        return availableFloors;
    }

    public void GivePriestSpawnPoint(GameObject priest)
    {
        Vector3 priestPosition = priest.GetComponent<Rigidbody2D>().transform.position;
        if (Player.instance.GetComponent<Rigidbody2D>().transform.position.x > middleOfHouseXPos)
        {
            priest.GetComponent<Rigidbody2D>().position = new Vector3(leftSideOfHouseXPos, priestPosition.y, priestPosition.z);
        } else
        {
            priest.GetComponent<Rigidbody2D>().position = new Vector3(rightSideOfHouseXPos, priestPosition.y, priestPosition.z);
        }
    }

    public void DeactivateAllPriests()
    {
        foreach(GameObject priest in priests)
        {
            priest.SetActive(false);
        }
    }
}
