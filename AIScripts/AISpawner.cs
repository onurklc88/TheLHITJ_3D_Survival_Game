using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    
    public GameObject deer;
    public GameObject rabbit;
    public int xPos;
    public int zPos;
    public int AICounter;






    void Start()
    {
        StartCoroutine(AIStartSpawn());
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    
    IEnumerator AIStartSpawn()
    {

        while (AICounter < 4)
        {


            xPos = Random.Range(50, 60);
            zPos = Random.Range(30, 20);
            Instantiate(deer, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            AICounter += 1;


        }



    }


}
