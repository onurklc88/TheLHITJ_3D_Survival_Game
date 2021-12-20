using UnityEngine;
using TMPro;

public class MapGenerate : MonoBehaviour
{

    public int forestSizex = 25; // Overall size of the forest (a square of forestSize X forestSize).
    public int forestSizey = 25;
    public TextMeshProUGUI SeedTxt;
    int treedensity;
    float treescale;

    public Element[] elements;

    float timeLeft = 10.0f;
    public GameObject Panel;
     void Update()
     {
         timeLeft -= Time.deltaTime;
   
         if (timeLeft < 0)
         {
            Panel.SetActive(false);
            
         }
     }
    private void Start()
    {
            SeedTxt.text = "Seed Code :" + getmapvalue.enc;
    }
    private void Awake()
    {
        treedensity = getmapvalue.newtreevalue;
        treescale = (float)getmapvalue.newscalevalue;
        for (int x = 1; x < forestSizex; x += treedensity)
        {

            for (int z = 1; z < forestSizey; z += treedensity)
            {

                // For each position, loop through each element...
                for (int i = 0; i < elements.Length; i++)
                {

                    // Get the current element.
                    Element element = elements[i];

                    // Check if the element can be placed.
                    if (element.CanPlace())
                    {


                        // Add random elements to element placement.
                        Vector3 position = new Vector3(x, 15f, z);
                        Vector3 offset = new Vector3(Random.Range(-30.75f, -25.75f), 0f, Random.Range(-30.75f, -25.75f));
                        Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360f), Random.Range(0, 5f));
                        Vector3 scale = Vector3.one *treescale; 

                        // Instantiate and place element in world.
                        GameObject newElement = Instantiate(element.GetRandom());
                        newElement.transform.SetParent(transform);
                        newElement.transform.position = position + offset;
                        newElement.transform.eulerAngles = rotation;
                        newElement.transform.localScale = scale;

                        // Break out of this for loop to ensure we don't place another element at this position.
                        break;

                    }

                }
            }
        }

    }
}

    [System.Serializable]
public class Element
{

    public string name;
    [Range(1, 10)]
    int density = 8;

    public GameObject[] prefabs;

    public bool CanPlace()
    {

        // Validation check to see if element can be placed. More detailed calculations can go here, such as checking perlin noise.

        if (Random.Range(0, 10) < density)
            return true;
        else
            return false;

    }

    public GameObject GetRandom()
    {

        // Return a random GameObject prefab from the prefabs array.

        return prefabs[Random.Range(0, prefabs.Length)];

    }

}