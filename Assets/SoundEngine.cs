using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEngine : MonoBehaviour
{
    public Player player;
    public AudioSource song1;
    public AudioSource song2;
    public AudioSource song3;
    public AudioSource song4;


    public float yfloor1 = 0f;
    public float yfloor2 = 6.3f;

    public float xmin1;
    public float xmax1;


    public float xmin2;
    public float xmax2;

    public float xmin3;
    public float xmax3;

    public float xmin4;
    public float xmax4;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.transform.position.x < xmax1 && player.transform.position.x > xmin1 && player.transform.position.x < yfloor1)
        {
            Debug.Log("ready for some tunes mboi");
        }
    }
}
