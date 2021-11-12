using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

   
    private Animator playerAnim;
    private PlayerMovement playerSpeed;
    public bool IsAxeTaken;

    public GameObject player;







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


        //crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerAnim.SetBool("Crouch", true);



        }
        else
        {
            playerAnim.SetBool("Crouch", false);

        }

        if((Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W)) || ((Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.A)) || ((Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.D)) || ((Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.S))))))
        {

            playerAnim.SetBool("CrouchWalk", true);

        }
        else
        {
            playerAnim.SetBool("CrouchWalk", false);

        }

        //JumpAnim
        if (Input.GetKey(KeyCode.Space))
        {

            playerAnim.SetBool("Jump", true);



        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            playerAnim.SetBool("Jump", false);

        }

        //axeAnimation
        
        if (IsAxeTaken == false && Input.GetKeyDown(KeyCode.Alpha1))
        {
      
                playerAnim.SetBool("axeTaken", true);
                IsAxeTaken = true;
            
        }
        else if(IsAxeTaken == true && Input.GetKeyDown(KeyCode.Alpha1))
        {

            playerAnim.SetBool("axeTaken", false);
            IsAxeTaken = false;

        }
       
        
            
            
           
        }
        

    }





