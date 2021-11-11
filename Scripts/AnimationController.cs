using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public GameObject player;
    private Animator playerAnim;
    private PlayerMovement playerSpeed;





    void Start()
    {
        playerSpeed = player.GetComponent<PlayerMovement>();

        playerAnim = GetComponent<Animator>();



    }

   
    void Update()
    {
        UpdateAnimation();

    }


    public void UpdateAnimation()
    {

        playerAnim.SetFloat("Speed", playerSpeed.speed);
       




    }


}
