using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public GameObject thisTree;
    public int treeHealth;
    public int axeDamage;
   public int counter;


    [SerializeField]
    //I put the items to store inside of what we want instanciate 
    public GameObject[] ItemsDeck;
    //Then I will fetch these objects from ýtemsDeck
    private GameObject[] insantanciatedObects;



    private bool isFallen = false;




    void Start()
    {

        thisTree = transform.gameObject;

    }



    void Update()
    {

        TreeFall();
       

    }


    public void TreeFall()
    {

        if (treeHealth <= 0 && isFallen == false)
        {
            //calling rigidbody to falling
            Rigidbody rb = thisTree.AddComponent<Rigidbody>();

            //setting RB 
            rb.isKinematic = false;
            rb.useGravity = true;
            //adding force to pushing rb
            rb.AddForce(Vector3.forward, ForceMode.Impulse);
           StartCoroutine(destroyTree());
           
            isFallen = true;
        }

    }


    


    private void OnTriggerEnter(Collider health)
    {


        if (health.gameObject.tag == "Axe")
        {
            Debug.Log("touch");
            //AI taking axe damage
            treeHealth -= axeDamage;


        }

    }

    public void ItemDrop()
    {

        //Drop the item until counter become a zero
        if (isFallen == true && counter > 0)
        {
            Debug.Log("sas");
            //Storing the items from inspector inside of instanciate object
            insantanciatedObects = new GameObject[ItemsDeck.Length];

            //I fetching items or objects from Stored list
            for (int i = 0; i < ItemsDeck.Length; i++)
            {
                //Now we can instanciate stored items

                insantanciatedObects[i] = Instantiate(ItemsDeck[i], transform.position, Quaternion.identity) as GameObject;

            }

            //counter become a 0 for this funciton can return once in update
            counter--;
        }


    }

    private IEnumerator destroyTree()
    {
        //waiting until destroying tree
        yield return new WaitForSeconds(5);
        ItemDrop();
        Destroy(thisTree);
        
    }

}


