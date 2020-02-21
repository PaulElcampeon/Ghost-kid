using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public LawnmowerMission lawnmower;
    public Renderer longGrassSprite;
    // Start is called before the first frame update
    void Start()
    {
        longGrassSprite = GetComponent<Renderer>();
        lawnmower = GameObject.FindObjectOfType<LawnmowerMission>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LawnMower" && lawnmower.isGassed)
        {
            longGrassSprite.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
