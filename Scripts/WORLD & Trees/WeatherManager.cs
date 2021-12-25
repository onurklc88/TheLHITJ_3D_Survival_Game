using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{

    public enum biome { NONE, FIRST_BIOME, SECOND_BIOME, THIRD_BIOME};
    public enum Weather {NONE, SUNNY, RAIN, SNOW};
    public Weather currentWeather;
    public biome currentBiome;
    
    //time settings
    public float weatherTime = 10f;
    public float sunnyTime;
    public float rainTime;
    public float snowTime;

    private void Start()
    {
        currentBiome = biome.FIRST_BIOME;
        currentWeather = Weather.SUNNY;
        this.weatherTime = this.sunnyTime;
    }
    private void Update()
    {
        weatherController();
    }

    public void changeWeather(Weather weatherType)
    {
        if(weatherType != this.currentWeather)
        {
           
               switch (weatherType)
                        {
                    case Weather.SUNNY:
                    currentWeather = Weather.SUNNY;
                    break;
                    case Weather.RAIN:
                    currentWeather = Weather.RAIN;
                    break;
                case Weather.SNOW:
                    currentWeather = Weather.RAIN;
                    break;

            }
                    
          }
        }

     
    public void weatherController()
    {
       

        if (this.currentWeather == Weather.SUNNY)
        {
            this.sunnyTime -= Time.deltaTime;
        }
        else
        {
            sunnyTime = weatherTime;
        }

        if (this.currentWeather == Weather.RAIN)
        {
            this.rainTime -= Time.deltaTime;
        }
        else
        {
            rainTime = weatherTime;
        }

        if (this.currentBiome == biome.FIRST_BIOME || this.currentBiome == biome.SECOND_BIOME)
        {
            if (this.sunnyTime <= 0f)
            {
                changeWeather(Weather.RAIN);


            }
            if (this.rainTime <= 0f)
            {
                changeWeather(Weather.SUNNY);
                rainTime = weatherTime;

            }
        }



    }


}
