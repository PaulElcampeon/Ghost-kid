using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Possessed
{
    [SerializeField]
    private AudioSource unpossessSFX;
    public bool isOnFloor;

    private void Start()
    {
        base.unPossessSFX = unpossessSFX;
    }

}
