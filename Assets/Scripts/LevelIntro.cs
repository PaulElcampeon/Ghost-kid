using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIntro : MonoBehaviour
{
    public GameObject panel;
    public float delay;
    public bool hasPlayed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && panel.active)
        {
            panel.SetActive(false);

            GameManager.instance.Resume();

        }
        /*if (panel.active)
        {
            delay -= Time.deltaTime;

            if (delay <= 0)
            {
                panel.SetActive(false);
                GameManager.instance.Resume();
            }
        }*/
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.gameObject.CompareTag("Player") && !hasPlayed)
        {
            panel.SetActive(true);
            hasPlayed = true;

            GameManager.instance.Pause();

        }

    }

}
