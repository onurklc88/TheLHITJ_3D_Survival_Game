using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEfect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Shoot();


        }
    }



    void Shoot()
    {

        muzzleFlash.Play();
        //define raycast
        RaycastHit hit;
        //using raycast to hit objects
       if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
        
            Debug.Log(hit.transform.name);
            
        }

       //fetching AIHealth script
       AIHealth target = hit.transform.GetComponent<AIHealth>();

        //if AIHealth Script is exist hit the damage
        if( target != null)
        {

            target.TakeDamage(damage);

        }
        //Instantiate(impactEfect, hit.point, Quaternion.LookRotation(hit.normal));
    }

}
