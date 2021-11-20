using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

   
    private Animator playerAnim;
    private PlayerMovement playerSpeed;
    private bool IsAxeTaken;
    private bool chopping;
    private bool IsPistolTaken;
    private bool pistolShooting;



    public GameObject player;
    public GameObject revolver;
    public GameObject axe;






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
        //if axe taken and
        if (IsAxeTaken == false && Input.GetKeyDown(KeyCode.Alpha1))
        {


            axe.SetActive(true);
            playerAnim.SetBool("axeTaken", true);
            playerAnim.SetBool("pistolTaken", false);
           
                IsAxeTaken = true;

        }
        else if(IsAxeTaken == true && Input.GetKeyDown(KeyCode.Alpha1) )
        {

            playerAnim.SetBool("axeTaken", false);
            IsAxeTaken = false;
            axe.SetActive(false);
        }
        if (IsAxeTaken == true && Input.GetKeyDown(KeyCode.Alpha2))
        {
            IsAxeTaken = false;
            axe.SetActive(false);
            playerAnim.SetBool("axeTaken", false);
            playerAnim.SetBool("pistolTaken", true);
            revolver.SetActive(true);
        }




        if (Input.GetMouseButtonDown(0) && IsAxeTaken == true)
        {
       
          
            playerAnim.SetTrigger("chopping");
            chopping = true;
            
        }

        //pistol animation
        
        //if pistol taken 
        if (IsPistolTaken == false && Input.GetKeyDown(KeyCode.Alpha2))
        {
            revolver.SetActive(true);
            playerAnim.SetBool("axeTaken", false);
            playerAnim.SetBool("pistolTaken", true);
            IsPistolTaken = true;

        }
        else if (IsPistolTaken == true && Input.GetKeyDown(KeyCode.Alpha2))
        {
            revolver.SetActive(false);
            playerAnim.SetBool("pistolTaken", false);
            IsPistolTaken = false;
         
        }
        if (IsAxeTaken == true && Input.GetKeyDown(KeyCode.Alpha1))
        {
            IsPistolTaken = false;
            revolver.SetActive(false);
            playerAnim.SetBool("pistolTaken", false);
            playerAnim.SetBool("axeTaken", true);
            axe.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && IsPistolTaken == true)
        {


            playerAnim.SetTrigger("pistolShooting");
            

        }





    }

 
   
}
        

    





