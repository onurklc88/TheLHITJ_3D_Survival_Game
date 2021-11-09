using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIAttack : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    private Animator animation; 

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
    public float sightRange, attackRange;
    public bool playerInsightRange, PlayerInAttcakRange;


    
   



    private void Awake()
    {

        animation = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        //declare speeds for any animal
        agent.speed = WalkingSpeed;
        agent.speed = RunSpeed;

        //
        playerInsightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        PlayerInAttcakRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInsightRange && !PlayerInAttcakRange)
        {

            Patrolling();
        }
        if (playerInsightRange && !PlayerInAttcakRange)
        {

            ChasePlayer();
        }
        if (PlayerInAttcakRange && playerInsightRange)
        {
            AttackPlayer();
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
    }


}
