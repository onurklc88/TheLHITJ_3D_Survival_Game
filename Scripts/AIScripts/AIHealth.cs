using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{

    public float AIHealth1;
    public float AxeDamage = 0;
    private float counter = 0.1f;


    public GameObject Animal;

    [SerializeField]
    //I put the items to store inside of what we want instanciate 
    public GameObject[] ItemsDeck;
    //Then I will fetch these objects from ýtemsDeck
    private GameObject[] insantanciatedObects;
    [HideInInspector] public bool hit;



    public bool Dead;
    private Animator anima;
    private AIPatrolling AISpeed;

    private void Awake()
    {

        anima = GetComponent<Animator>();
        
    }


    void Start()
    {
        
       
     
      
    }


    void Update()
    {
        Death();
        ItemDrop();
        
        
    }
   


    private void OnTriggerEnter(Collider TakeDamage)
    {


        //if AI touch with axe
        if (TakeDamage.gameObject.tag == "Axe")
        {
            //AI taking axe damage
            AIHealth1 -= AxeDamage;
             Debug.Log(AIHealth1);

        }
       



    }
    //taking damage by guns
   public void TakeDamage (float amount)
    {

        AIHealth1 -= amount;
        hit = true;
        if(AIHealth1 <= 0f)
        {
           
            Death();

        }



    }




   public void Death()
    {
        Dead = false;

        if (AIHealth1 <= 0)
        {
           
            Dead = true;
        }

        
    }

   public void ItemDrop()
    {
        
        //Drop the item until counter become a zero
        if (Dead == true && counter > 0)
        {
            //Storing the items from inspector inside of instanciate object
            insantanciatedObects = new GameObject[ItemsDeck.Length];

            //I fetching items or objects from Stored list
            for (int i = 0; i < ItemsDeck.Length; i++)
            {
                //Now we can instanciate stored items

                insantanciatedObects[i] = Instantiate(ItemsDeck[i], transform.position, Quaternion.identity) as GameObject;
                
            }

            //counter become a 0 for this funciton can return once
            counter--;
        }


    }
}
