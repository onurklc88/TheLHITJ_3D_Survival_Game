using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{

    public enum biome { NONE, FIRST_BIOME, SECOND_BIOME, THIRD_BIOME};
    public enum Weather {NONE, SUNNY, RAIN, SNOW};
    public Weather currentWeather;
    public biome currentBiome;


    [Header("Light Settings")]
    public Light sunLight;
    public float defaultLightIntensity;
    public float rainLightIntensity;
    public float winterLightIntensity;

    private Color defaultLightColor;
    public Color rainColor;
    public Color winterColor;


    //time settings
    public static float timer;
    public float weatherTime = 10f;
    public float sunnyTime;
    public float rainTime = Mathf.FloorToInt(timer / 60f);
    public float snowTime;
    //fog settings
    public float endDistance = 60f;

    private void Start()
    {
        endDistance = 60f;
        currentBiome = biome.FIRST_BIOME;
        currentWeather = Weather.SUNNY;
        this.weatherTime = this.sunnyTime;
        //endDistance = RenderSettings.fogEndDistance;
        this.defaultLightColor = this.sunLight.color;
        this.defaultLightIntensity = this.sunLight.intensity;
       
    }
    private void Update()
    {
      
        weatherController();

        if(this.currentBiome == biome.THIRD_BIOME)
        {
            RenderSettings.fogColor = Color.black;
            if(endDistance >= 5f)
            {
                endDistance -= Time.deltaTime;
                RenderSettings.fogEndDistance = endDistance;
            }
           

        }
       
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
            this.sunnyTime -= Time.deltaTime / 60;
            aLerpLightColor(this.sunLight, defaultLightColor);
        }
        else
        {
            sunnyTime = weatherTime;
        }

        if (this.currentWeather == Weather.RAIN)
        {
            
            rainTime -= Time.deltaTime / 60f;
            aLerpLightColor(this.sunLight, rainColor);
            
        }
        else
        {
            rainTime = weatherTime * 3f;
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
                

            }
        }

    }
    private void aLerpLightColor(Light light, Color c)
    {
        light.color = Color.Lerp(light.color, c, 0.2f * Time.deltaTime);


    }

}
