using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeScript : MonoBehaviour
{

    private IEnumerator coroutine;
    public ParticleSystem chopEffect;
    public ParticleSystem bloodEffect;


    void Start()
    {
        GetComponent<Collider>().enabled = false;
        
    }

    
    void Update()
    {

        colliderTrigger();
    }


    


    private void OnTriggerEnter(Collider tree)
    {
        //effect = true;
        if(tree.gameObject.tag == "tree"){

            //chopEffect.Play();
            //effect = false;
            StartCoroutine(asdsad());
        }

        if(tree.gameObject.tag == "animal")
        {


            bloodEffect.Play();

        }




    }

    public void colliderTrigger()
    {

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(chopCollider());
         
            GetComponent<Collider>().enabled = true;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(chopCollider());
            


        }



    }

   private IEnumerator chopCollider()
    {

        
        
            yield return new WaitForSeconds(.8f);
        
        GetComponent<Collider>().enabled = false;


    }


    private IEnumerator asdsad()
    {



        yield return new WaitForSeconds(.8f);

        chopEffect.Play();


    }
}
