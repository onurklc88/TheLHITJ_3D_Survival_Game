using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolling : MonoBehaviour
{
    
    public Transform[] points;
    
    private Transform targetWayPoint;
    int current;
    //movement
    private float speed;
    public float runSpeed;
    public float walkSpeed;
    private float rotationSpeed = 2.0f;
    //animations
    private Animator anim;
    public float currentPatrolTime = 0;
    public float currentBreakTime = 0;
    public float patrolTime = 10f;
    public float breakTime = 2f;
    private int counter = 1;

    private void Awake()
    {
        //animator set
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        currentPatrolTime = patrolTime;
   
        current = 0;
        var playerAgent = GetComponent<NavMeshAgent>();


    }


    void Update()
    {

        //Updating current waypoint for AI rotation
        targetWayPoint = points[current];

        AIPatrol();
        Rotation();
        Dead();
        AIbBehaviour();


    }


    public void AIPatrol()
    {
        if (transform.position != points[current].position)
        {
            //if AI position is not equal to waypoint,AI move towards to waypoint
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);

        }
        else
        {
            //if AI position is equal to waypoint,AI move towards to next wayPoint
            current = (current + 1) % points.Length;
            
          

        }


    }

    public void AIbBehaviour()
    {

        AIHealth health = GetComponent<AIHealth>();

        if(health.AIHealth1 >= 100 && currentPatrolTime > 0)
        {
           
            currentPatrolTime -= 1 * Time.deltaTime;
            speed = runSpeed;
            //animation.SetBool("chase", false);
            anim.SetFloat("patrolTimer", currentPatrolTime);
            
                if (currentPatrolTime <= 0)
                {
                speed = walkSpeed;
                currentBreakTime = breakTime;

                   }
             }

        if(health.hit == false && currentPatrolTime <= 0)
        {
            currentBreakTime -= 1 * Time.deltaTime;
            anim.SetFloat("breakTimer", currentBreakTime);
                
                if(currentBreakTime <= 0)
                {
                currentPatrolTime = patrolTime;

            }
             }

        if (health.hit == true)
        {
            
            if(counter == 1)
            {
                counter--;
                currentPatrolTime = patrolTime * 2;
            }
             speed = runSpeed;
            currentPatrolTime -= 1 * Time.deltaTime;
            anim.SetFloat("patrolTimer", currentPatrolTime);
            if (currentPatrolTime <= 0)
            {
                Debug.Log("girdi");
                health.hit = false;
                speed = walkSpeed;
                currentBreakTime = breakTime;

            }

        }



    }




    public void Rotation()
    {

        float rotationStep = rotationSpeed * Time.deltaTime;
        
        
        Vector3 directionToTarget = targetWayPoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        transform.rotation = rotationToTarget;


    }
    public void Dead()
    {
        
        AIHealth health = GetComponent<AIHealth>();
        if(health.AIHealth1 <= 0)
        {
            //calling Death animation
            anim.SetBool("isDead", true);
            speed = 0;
            Destroy(gameObject, 1f);
        }


    }



}
