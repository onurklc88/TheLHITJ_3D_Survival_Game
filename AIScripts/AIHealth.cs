using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{

    public float AIHealth1 = 100f;
    public float AxeDamage = 0;
    public float BulletDamage = 0;
    public float counter = 0.1f;


    public GameObject Animal;

    [SerializeField]
    //I put the items to store inside of what we want instanciate 
    public GameObject[] ItemsDeck;
    //Then I will fetch these objects from ýtemsDeck
    private GameObject[] insantanciatedObects;



    
    public bool Dead;
    private Animator anima;
    private AIPatrolling AISpeed;

    private void Awake()
    {

        anima = GetComponent<Animator>();
        
    }


    void Start()
    {
        
        AISpeed = Animal.GetComponent<AIPatrolling>();
     
      
    }


    void Update()
    {
        Death();
        ItemDrop();
        
        
    }
   


    private void OnTriggerEnter(Collider TakeDamage)
    {


        //if AI touch with axe
        if (TakeDamage.gameObject.tag == "axe")
        {
            //AI taking axe damage
            AIHealth1 -= AxeDamage;


            Debug.Log(AIHealth1);

        }
        //if AI touch with bullet
        if (TakeDamage.gameObject.tag == "bullet")
        {
            //AI taking bullet damage
            AIHealth1 -= BulletDamage;


        }



    }

   




   public void Death()
    {
        Dead = false;

        if (AIHealth1 == 0)
        {
            //calling Death animation
            anima.SetBool("isDead", true);

            //set AI speed 0
            AISpeed.speed = 0f;

            //destroy
            Destroy(gameObject, 1f);


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
