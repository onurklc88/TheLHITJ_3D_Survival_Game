using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIAttack : MonoBehaviour
{


    public GameObject stealthSpeed;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Transform pointOfView;

    //agent speed
    public float WalkingSpeed;
    public float RunSpeed;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;


    //Attack
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange;
    public float attackRange;
    public float viewRange;
    public bool playerInsightRange, PlayerInAttcakRange;
    public bool animalPointOfView;
    //animation
    private Animator animation;
    private PlayerMovement playerMovementScript;






    private void Awake()
    {

        animation = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        playerMovementScript = stealthSpeed.GetComponent<PlayerMovement>();


    }


    void Start()
    {
        
    }

    
    void Update()
    {
        //declare speeds for any animal
        agent.speed = WalkingSpeed;
        agent.speed = RunSpeed;

        //setting sigth and attack range
        playerInsightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        PlayerInAttcakRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        animalPointOfView = Physics.CheckSphere(pointOfView.transform.position, viewRange, whatIsPlayer);
        AIStates();

    }

    public void AIStates()
    {
        //if AI doesnt look to enemy then patrolling
        if (!PlayerInAttcakRange && !animalPointOfView)
        {
               Patrolling();

        }

        //is player playing stealth 
        if (playerInsightRange && playerMovementScript.speed == 1)
        {

            Patrolling();

        }
        else if(playerInsightRange && playerMovementScript.speed != 1)
        {

            ChasePlayer();

        }

        if (animalPointOfView && !PlayerInAttcakRange)
        {
             ChasePlayer();
        }
        if (PlayerInAttcakRange && playerInsightRange && pointOfView)
        {
            AttackPlayer();
        }
        if (animalPointOfView && !PlayerInAttcakRange)
        {

            ChasePlayer();

        }






    }

    private void Patrolling()
    {

        if (!walkPointSet)
        {
              SearchWalkPoint();
        }

        if (walkPointSet)
        {
            animation.SetBool("Walk", true);
            animation.SetBool("Chase", false);
            animation.SetBool("Attack", false);
            agent.speed = WalkingSpeed;
            agent.SetDestination(walkPoint);


        }
            

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;



    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
            

        }
     
       
    }



    private void ChasePlayer()
    {
        animation.SetBool("Walk", false);
        animation.SetBool("Chase", true);
        animation.SetBool("Attack", false);
        agent.speed = RunSpeed;
        agent.SetDestination(player.position);


    }
    private void AttackPlayer()
    {
        animation.SetBool("Chase", false);
        animation.SetBool("Attack", true);
        agent.SetDestination(transform.position);
        transform.LookAt(player.position);

        if (!alreadyAttacked)
        {

          
            Debug.Log("hit");

            
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }



    }
    private void ResetAttack()
    {
        animation.SetBool("Attack", false);
        alreadyAttacked = false;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pointOfView.transform.position, viewRange);
    }


}
