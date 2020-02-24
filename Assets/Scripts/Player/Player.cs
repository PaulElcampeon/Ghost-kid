using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canPossess;
    public GameObject possesableObj;
    public Animator animator;
    public Vector3 playerStartingPoint;
    private PlayerAnimator playerAnimator;
    private bool isDead;

    public static Player instance;
  
    void Start()
    {
        instance = this;
        transform.position = playerStartingPoint;
        playerAnimator = gameObject.GetComponent<PlayerAnimator>();
        StartCoroutine(SpawnPlayerIn());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !GameManager.instance.gameEnded && !GameManager.instance.gamePaused && !GameManager.instance.isPossessing)
        {
            if (canPossess && possesableObj != null)
            {
                GameManager.instance.isPossessing = true;

                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                playerAnimator.Possess();
            }
        }
    }

    public void Possess()
    {
        possesableObj.GetComponent<PossessableMovement>().enabled = true;
        CameraController.instance.target = possesableObj.GetComponent<Rigidbody2D>().transform;

        /*
        We could disbale the player and playerMovement script but they will get disabled when we the gameObject active to false
         * */
        canPossess = false;
        possesableObj.GetComponent<Possessed>().Possess();
        gameObject.SetActive(false);
    }

    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            playerAnimator.Death();
        }
    }

    public void Unpossess()
    {
        playerAnimator.Unpossess();
    }

    public void ShowPlayer()
    {
        Player.instance.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void ResumeIdle()
    {
        playerAnimator.Idle();
    }

    public IEnumerator SpawnPlayerIn()
    {
        yield return new WaitForSeconds(2f);
        Unpossess();
    }

    public void InformGameManagerOfMyDeath()
    {
        GameManager.instance.isDead = true;
    }
}
