using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControlForTree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "deneme")
        {
            Debug.Log("Triggered by Enemy");
        }
    }
}
