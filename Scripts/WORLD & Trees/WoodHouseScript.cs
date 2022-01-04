using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodHouseScript : MonoBehaviour
{
    public static WoodHouseScript InCeilingRange;
    public bool houseInSightRange;
  

    private void Awake()
    {
        InCeilingRange = this;
    }
    void Start()
    {
        houseInSightRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

    if(other.gameObject.tag == "Player")
        {
            houseInSightRange = true;
          
        }
       

    }
    
    private void OnTriggerExit(Collider other)
    {

        houseInSightRange = false;
      
    }
    
}
