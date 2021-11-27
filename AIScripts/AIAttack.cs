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
    private PlayerMovement playerMovementScript;
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
    public float patrolTime = 10f;
    public float breakTime = 10f;
    private float currentPatrolTime = 0;
    private float currentBreakTime = 0;
    






    private void Awake()
    {

        animation = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        playerMovementScript = stealthSpeed.GetComponent<PlayerMovement>();


    }


    void Start()
    {
        currentPatrolTime = patrolTime;
      
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
        Dead();
        updateAnimation();
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


    private void updateAnimation()
    {
       
        //patrol
        if (!PlayerInAttcakRange && !animalPointOfView && currentBreakTime <= 0 || playerInsightRange && playerMovementScript.speed == 1 & currentBreakTime <= 0)
        {
            currentPatrolTime -= 1 * Time.deltaTime;
            animation.SetBool("chase", false);
            animation.SetFloat("patrolTime", currentPatrolTime);
            if(currentPatrolTime <= 0)
            {
                currentBreakTime = breakTime;

            }

        }

       if(!PlayerInAttcakRange && !animalPointOfView && currentPatrolTime <= 0 || playerInsightRange && playerMovementScript.speed == 1 & currentPatrolTime <= 0)
        {
            currentBreakTime -= 1 * Time.deltaTime;
            animation.SetBool("chase", false);
            animation.SetFloat("breakTime", currentBreakTime);
            agent.speed = 0;
            
            if(playerInsightRange && playerMovementScript.speed != 1)
            {
                currentBreakTime = 0;
                agent.speed = RunSpeed;
                animation.SetBool("chase", true);
               
              }


            if (currentBreakTime <= 0)
            {
                agent.speed = WalkingSpeed;
                currentPatrolTime = patrolTime;

               }

          


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
            if (agent.speed != 0)
            {
                agent.speed = WalkingSpeed;
                agent.SetDestination(walkPoint);
            }

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
        animation.SetBool("attack", false);
        animation.SetBool("chase", true);
        
        agent.speed = RunSpeed;
        agent.SetDestination(player.position);


    }
    private void AttackPlayer()
    {
        animation.SetBool("attack", true);
        animation.SetBool("chase", false);
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
    private void Dead()
    {
        //if AI is dead it speed is
        AIHealth health = GetComponent<AIHealth>();
        if (health.AIHealth1 <= 0)
        {
            Debug.Log("Advance aý dead");
            agent.speed = 0;
            Destroy(gameObject, 3f);
        }



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
