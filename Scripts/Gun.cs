using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float reloadTime = 60f;
    public int maxAmmo = 6;
    public int magazineSize = 12;
   
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEfectAnimal;
    public GameObject impactEffectWorld;
    public GameObject player;
    public TextMeshProUGUI ammoInfoText;

    [HideInInspector] public bool canShoot = true;
    [HideInInspector] public int currentAmmo;


    private bool isReloading = false;
    private Animator pistolAnim;


    private void Start()
    {
        pistolAnim = player.GetComponent<Animator>();
        currentAmmo = maxAmmo;
    }

  

    void Update()
    {
        FireInput();
        pistolReload();
        ammoInfoText.text = this.currentAmmo + " / " + this.magazineSize;
    }


    public void FireInput()
    {

       

        if (Input.GetMouseButtonDown(0))
        {
       
            if(canShoot == true)
            {
                
                Shoot();

                canShoot = false;
                StartCoroutine(timeBetweenShots());
            }
           
           

        }
     
    }

    

public void Shoot()
    {

        
      if(canShoot == true)
        {
            currentAmmo--;

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


}



    public void pistolReload()
    {
        if (isReloading)
        {
            return;
        }

     
       
        if (currentAmmo == 0 && magazineSize == 0)
        {
            canShoot = false;
            pistolAnim.SetBool("pistolReload", false);
          
            return;

        }
        else if(currentAmmo > 0 || magazineSize > 0)
        {

            canShoot = true;

        }
       if(currentAmmo == 0 && isReloading == false)
        {
            StartCoroutine(Reload());
            return;

        }
     

    }



   IEnumerator Reload()
    {


        if (magazineSize >= maxAmmo)
        {

            currentAmmo = maxAmmo;
            magazineSize = magazineSize - maxAmmo;
           
        }
        else
        {
            currentAmmo = magazineSize;
            magazineSize = 0;

        }

        isReloading = true;
        pistolAnim.SetBool("pistolReload", true);
        yield return new WaitForSeconds(reloadTime);
        pistolAnim.SetBool("pistolReload", false);
         isReloading = false;

    }




    private IEnumerator timeBetweenShots()
    {
       
        //waiting until
      
        
            pistolAnim.SetTrigger("pistolShooting");

       
       
        yield return new WaitForSeconds(0.3f);
        canShoot = true;



    }




}
