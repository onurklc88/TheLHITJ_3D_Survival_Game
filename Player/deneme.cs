using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    // Start is called before the first frame update


    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.W))
            {

            anim.SetBool("walk", true);
           

        }
        */
       
        if(Input.GetKeyDown(KeyCode.W))
        {

            anim.SetBool("running", true);

        }
       

    }
}
