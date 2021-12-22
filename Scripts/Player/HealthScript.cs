using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthScript : MonoBehaviour
{
   
    
   [HideInInspector] public float playerHealth;
   [HideInInspector] public float maxHealth = 100f;
    private float currentHealth;
    public bool damageTaken;
    public Image bloodImage;
    public PlayerMovement movementScript;
    public float healthPercent;
    private bool Healing;

   

    void Start()
    {
       
        playerHealth = maxHealth;
        currentHealth = playerHealth;
        movementScript = FindObjectOfType<PlayerMovement>();

    }

    
    void Update()
    {
        
        takeDamageKnock();
        knockBackController();
        Heal();
    }

    public void takeDamage(float amount)
    {
       
        if (playerHealth > 0) {

            currentHealth = playerHealth;
            playerHealth -= amount;
          
            

        }
        else
        {

            Debug.Log("player is dead");
        }
      

    }

    public void knockBackController()
    {


        if(currentHealth > playerHealth)
        {

            damageTaken = true;
        }
        
    }


    public void knockBack(Vector3 direction)
    {

        movementScript.KnockBack(direction);


    }

    public void takeDamageKnock()
    {

        if (damageTaken == true)
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
            currentHealth = playerHealth;
            healthPercent = (maxHealth - playerHealth) / 100;
            bloodImage.color = new Color(255, 0, 0, healthPercent);
         
            

        }



    }
    IEnumerator knockBack()
    {
        yield return new WaitForSeconds(1.1f);

       Vector3 hitDirection = transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z + 0.2f);
        
       hitDirection = hitDirection.normalized;
        knockBack(hitDirection);
        damageTaken = false;
        currentHealth = playerHealth;
    }
}
