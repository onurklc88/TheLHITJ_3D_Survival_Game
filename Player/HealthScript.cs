using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Text healthText;
    
    private float playerHealth;
    private float maxHealth = 100f;

    public float thrust = 5f;
    public Rigidbody rigidBody;

    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerHealth = maxHealth;
        
    }

    
    void Update()
    {

        healthText.text = "" +playerHealth;

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

    public void Heal(float amount)
    {
      


    }

}
