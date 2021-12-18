using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthScript : MonoBehaviour
{
   
    
   [HideInInspector] public float playerHealth;
   [HideInInspector] public float maxHealth = 100f;

    public Image bloodImage;
    public PlayerMovement movementScript;
    public float healthPercent;
    private bool Healing;

   

    void Start()
    {
       
        playerHealth = maxHealth;
        movementScript = FindObjectOfType<PlayerMovement>();

    }

    
    void Update()
    {
      
        asd();
        Heal();
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
    public void UpdateBloodImage()
    {

      
            healthPercent = (maxHealth - playerHealth) / 100;
            bloodImage.color = new Color(255, 0, 0, healthPercent);
            
        }

    public void Heal()
    {


       
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("girdi");
            playerHealth += 20;
            
            healthPercent = (maxHealth - playerHealth) / 100;
            bloodImage.color = new Color(255, 0, 0, healthPercent);
         
            

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
