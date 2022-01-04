using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class thirstSystem : MonoBehaviour
{

    public float maxThirst = 100f;
    public float currentThirst;
    public Image ringHungerBar;
    public GameObject player;


    public float thirstTimer = 15f;
    private float thirstCounter = 5f;
    private float lerpSpeed;
    private float degreePercentage;
    private HealthScript HSript;
    public static thirstSystem thirstSystemScript;


    private void Awake()
    {

    }
    private void Start()
    {
        HSript = player.GetComponent<HealthScript>();
        currentThirst = maxThirst;


    }
    private void Update()
    {



        //if (maxHunger > currentHunger) currentHunger = maxHunger;

        lerpSpeed = 3f * Time.deltaTime;

        StarveBarFiller();
        ColorChanger();
        damageToPlayer();
        decreaseHunger();

    }



    void StarveBarFiller()
    {

        ringHungerBar.fillAmount = Mathf.Lerp(ringHungerBar.fillAmount, (currentThirst / maxThirst), lerpSpeed);


    }
    void ColorChanger()
    {
        //changing color of health color
        Color healthColor = Color.Lerp(Color.green, Color.blue, (currentThirst / maxThirst));
        ringHungerBar.color = healthColor;
    }




    public void decreaseHunger()
    {
        if (thirstTimer > 0)
        {
            currentThirst -= 0.00015f;
            thirstTimer -= 0.010f * Time.deltaTime;

        }
        else if (thirstTimer <= 0)
        {
            thirstTimer = 15f;
        }

    }
    public void increase(float increaseHunger)
    {
        if (currentThirst < maxThirst)
            currentThirst += increaseHunger;
    }


    public void damageToPlayer()
    {

        if (currentThirst < 10f && maxThirst > 0)
        {

            if (thirstCounter >= 5f)
            {
                HSript.takeDamage(5f);
                thirstCounter -= 5f;
            }
            else
            {
                thirstCounter += 1f * Time.deltaTime;
            }


        }



    }

}
