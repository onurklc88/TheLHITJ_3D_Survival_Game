using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeScript : MonoBehaviour
{

    private IEnumerator coroutine;




    void Start()
    {
        GetComponent<Collider>().enabled = false;
        
    }

    
    void Update()
    {

        colliderTrigger();
    }


    public void colliderTrigger()
    {

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(asddsa());
            Debug.Log("a�t�");
            GetComponent<Collider>().enabled = true;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(asddsa());
            


        }



    }

   private IEnumerator asddsa()
    {

        
        
            yield return new WaitForSeconds(.8f);
        Debug.Log("��kt�");
        GetComponent<Collider>().enabled = false;


    }
}
