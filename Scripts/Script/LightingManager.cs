using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
 
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    [HideInInspector] public bool midnight;

    float day = 1;
    bool controller = false;

    [SerializeField, Range(0, 24)] private float TimeOfDay;
    public GameObject dayUI;

    //public Text dayText;
    public TextMeshProUGUI dayText;

    public float sunrise;
    public float sunriseExit;
    public float midnightStart;
    public float midnightEnd;
  
    public int dayminute;
    float timefactor = 2.5f;

    public Animator DayAnim;

    private void Update()
    { 
        if (((int)TimeOfDay) == sunrise)
        {
            DayAnim.SetBool("textcycle", true);
        }
        else if(((int)TimeOfDay) == sunriseExit)
        {
            DayAnim.SetBool("textcycle", false);
        }
        if(((int)TimeOfDay) == midnightStart)
        {
            midnight = true;

           
        }
        else if(((int)TimeOfDay) == midnightEnd)
        {
            midnight = false;

        }


        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            TimeOfDay += Time.deltaTime/timefactor/dayminute; // Gün döngüsü normal tamamlanmasý 24 saniye * 25 = 600 saniye
            if (TimeOfDay >= 24)
            {
                day++;
            }
            TimeOfDay %= 24; //Modulus to ensure always between 0-24

            UpdateLighting(TimeOfDay / 24f);

           
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
        dayText.text = "Day  " + day.ToString();
    }


    private void UpdateLighting(float timePercent)
        
    {
        
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}