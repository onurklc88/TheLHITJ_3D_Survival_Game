using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campfire : MonoBehaviour
{
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
     if(other.gameObject.tag == "Player")
        {
            
                FreezingSystem.freezeSystem.increase(0.05f);
              
            
        }   
    }
}
   

