using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthScript : MonoBehaviour
{
   
    
   [HideInInspector] public float playerHealth;
   [HideInInspector] public float maxHealth = 100f;


    public PlayerMovement movementScript;


   

    void Start()
    {
       
        playerHealth = maxHealth;
        movementScript = FindObjectOfType<PlayerMovement>();

    }

    
    void Update()
    {

        asd();
       
    }

    public void takeDamage(float amount)
    {
       
        if (playerHealth > 0) {

           
            playerHealth -= amount;
        
            
        }
        else
        {

            Debug.Log("player is dead");
        }
      

    }

    public void knockBack(Vector3 direction)
    {

        movementScript.KnockBack(direction);


    }

    public void asd()
    {

        if (AIAttack.AIAttackScript.alreadyAttacked == true)
        {

            StartCoroutine(knockBack());
            
          }

         
    }
    public void Heal()
    {


       
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("girdi");
            

        }



    }
    IEnumerator knockBack()
    {
        yield return new WaitForSeconds(1.2f);
      
        Vector3 hitDirection = transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z + 0.1f);

        hitDirection = hitDirection.normalized;
        knockBack(hitDirection);
        

    }
}
