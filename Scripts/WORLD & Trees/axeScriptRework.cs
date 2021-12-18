using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeScriptRework : MonoBehaviour
{
    private float range = 2f;
    public Camera fpsCam;
    public float axeDamage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chopping();
    }

    public void chopping()
    {


        if (Input.GetMouseButtonDown(0))
        {
            //define raycast
            RaycastHit hit;
            //using raycast to hit objects
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward);
                Debug.Log(hit.transform.name);
               
            }
            else
            {
                Debug.Log("yeter");
            }


            TreeScript treeHealthScript = hit.transform.GetComponent<TreeScript>();
            if (treeHealthScript != null)
            {
                Debug.Log("girdiiiiiiiiiiiiii");
                treeHealthScript.TakeDamage(axeDamage);

            }
            //fetching tree script



        }


    }

}
