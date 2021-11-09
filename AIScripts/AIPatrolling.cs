using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolling : MonoBehaviour
{
    
    public Transform[] points;
    private Animator anim;
    private Transform targetWayPoint;
    int current;
    public float speed;
    private float rotationSpeed = 2.0f;


    private void Awake()
    {
        //animator set
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        current = 0;
        var playerAgent = GetComponent<NavMeshAgent>();


    }


    void Update()
    {

        //Updating current waypoint for AI rotation
        targetWayPoint = points[current];

        AIPatrol();
        Rotation();




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


    public void Rotation()
    {

        float rotationStep = rotationSpeed * Time.deltaTime;
        
        //
        Vector3 directionToTarget = targetWayPoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        transform.rotation = rotationToTarget;


    }




}
