using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject deer;
    public GameObject rabbit;
    
    
    public int maxNumberOfRabbit;
    public int maxNumberOfDeer;


   public int numberOfDeer = 0;
   public int numberOfRabbit = 0;

    private AIHealth AIScript;
    private float xPos;
    private float zPos;
    

    void Start()
    {
        AIScript = deer.GetComponent<AIHealth>();
        StartCoroutine(AIStartSpawn());
    
    }

    
    void Update()
    {

        currentNumberOfAI();
       
    }

    
        IEnumerator AIStartSpawn()
    {

        //spawning AI until deer AI counter reach numerOfAI
        while (numberOfDeer < maxNumberOfDeer)
        {
           
            //giving random x and z axis between spawn point
            xPos = Random.Range(spawnPosition.transform.position.x, spawnPosition.transform.position.x + 10f);
            zPos = Random.Range(spawnPosition.transform.position.z, spawnPosition.transform.position.z + 30f);
            //Instantiate AI
            Instantiate(deer, new Vector3(xPos, spawnPosition.transform.position.y, zPos) , Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            numberOfDeer += 1;


        }
        
        //spawning AI until rabbit AI counter reach numerOfAI
        while (numberOfRabbit < maxNumberOfRabbit)
        {

            //giving random x and z axis between spawn point
            xPos = Random.Range(spawnPosition.transform.position.x, spawnPosition.transform.position.x + 10f);
            zPos = Random.Range(spawnPosition.transform.position.z, spawnPosition.transform.position.z + 30f);
            //Instantiate AI
            Instantiate(rabbit, new Vector3(xPos, spawnPosition.transform.position.y, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            numberOfRabbit += 1;


        }
        

    }
    public void currentNumberOfAI()
    {
        
    
        //if AI killed by player spawn new one
        if (numberOfDeer != maxNumberOfDeer)
        {

            xPos = Random.Range(spawnPosition.transform.position.x, spawnPosition.transform.position.x + 10f);
            zPos = Random.Range(spawnPosition.transform.position.z, spawnPosition.transform.position.z + 30f);
            //Instantiate AI
            Instantiate(deer, new Vector3(xPos, spawnPosition.transform.position.y, zPos), Quaternion.identity);
            numberOfDeer += 1;


        }
        //if AI killed by player spawn new one
        if (numberOfRabbit != maxNumberOfRabbit)
        {

            xPos = Random.Range(spawnPosition.transform.position.x, spawnPosition.transform.position.x + 10f);
            zPos = Random.Range(spawnPosition.transform.position.z, spawnPosition.transform.position.z + 30f);
            //Instantiate AI
            Instantiate(rabbit, new Vector3(xPos, spawnPosition.transform.position.y, zPos), Quaternion.identity);
            numberOfRabbit += 1;


        }
        

    }

}




