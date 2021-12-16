using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
   
    
   [HideInInspector] public float playerHealth;
   [HideInInspector] public float maxHealth = 100f;

    public float thrust = 20f;
 
    public bool canHit1 = true;
    Vector3 currentPosition;
    Rigidbody rb;

    void Start()
    {
       
        playerHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        currentPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
      

    }

    
    void Update()
    {
       
        Heal();
       
    }

    public void takeDamage(float amount)
    {
        Vector3 deneme = new Vector3(transform.position.x, transform.position.y, transform.position.z);
      
      

        if (playerHealth > 0) {
            
                playerHealth -= amount;
            

        }
        else
        {

            Debug.Log("player is dead");
        }


    }

    public void Heal()
    {


       
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("girdi");
            rb.velocity = currentPosition * thrust;

        }



    }

}
