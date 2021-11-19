using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEfectAnimal;
    public GameObject impactEffectWorld;

    private bool canShoot;

   

    // Update is called once per frame
    void Update()
    {
        FireInput();
     
    }


    public void FireInput()
    {
       

        if (Input.GetMouseButtonDown(0))
        {
       
            if(canShoot == false)
            {
                
                Shoot();
                canShoot = true;
                StartCoroutine(timeBetweenShots());
            }
           
           

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



       //if hit object tag is not equal to animal 

      if(hit.transform.tag != "animal")
        {
            GameObject impactObect = Instantiate(impactEffectWorld, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObect, 2f);

        }

       


        //fetching AIHealth script
        AIHealth target = hit.transform.GetComponent<AIHealth>();

        //if AIHealth Script is exist hit the damage
        if( target != null)
        {

            target.TakeDamage(damage);
            GameObject impactGO = Instantiate(impactEfectAnimal, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }

     

    }

    private IEnumerator timeBetweenShots()
    {
        //waiting until destroying tree


        yield return new WaitForSeconds(0.3f);
        canShoot = false;

    }




}
