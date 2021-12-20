using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class getmapvalue : MonoBehaviour
{
    public Slider TreeDensity;
    public Slider TreeScale;
    //public static int treevalue;
    //public static double treeScalevalue;
    public TMP_InputField SeedInput;
    static char[] Seed = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L' };
    //K = .(nokta)
    //L = -(tire)
    //public static string[] SeedCode = new string[5];

    public static int newtreevalue;
    public static double newscalevalue;
    public static string enc;
       
    //public static string deneme;
    public GameObject CreateMap1, CreateMap2, MapSeedCode1, MapSeedCode2;

    //int sayac;

    public void btn_change_scene(string scene_name)
    {
        newtreevalue = (int)TreeDensity.value;
        newscalevalue = TreeScale.value;
        newscalevalue = Math.Round(newscalevalue, 2);
        SceneManager.LoadScene(scene_name);

        enc = encript(newtreevalue, newscalevalue);

    }
    public void SeedEnc(string scene)
    {
        if (SeedInput.text.IndexOf("L") == 2 && SeedInput.text.Length ==7)
        {
            string[] values = SeedInput.text.Split('L');

             newtreevalue = getTreeValue(values[0]);
             newscalevalue = getScaleValue(values[1]);
            if (newtreevalue!= -1 && newscalevalue!= -1)
            {
                if ((newtreevalue>=10 && newtreevalue<=17)&&(newscalevalue>=0.75&&newscalevalue<=1.25))
                {
                    print("sahne yüklendi");
                    //BHLAKHF
                    SceneManager.LoadScene(scene);
                    enc = encript(newtreevalue, newscalevalue);
                }
                else
                {
                    print("Sýnýr deðerler aþýldý");
                }
            }
            else
            {
                print("geçersiz2");
            }
            
        }
        else
        {
            print("Tire yok ise Seed hatalý");
        }
    }

    public static string encript(int a, double b)
    {
        string value1 = a.ToString() + "-" + b.ToString();
        string output = "";

        for (int i = 0; i < value1.Length; i++)
        {

            if (value1[i] == ',')
            {
                output += 'K';
            }
            else if (value1[i] == '-')
            {
                output += 'L';
            }
            else
            {
                string tmpChar = value1[i].ToString();
                int tmp = Convert.ToInt32(tmpChar);
                output += Seed[tmp];
            }
        }

        return output;

    }
    public static int getTreeValue(string s)
    {
        string output = "";
        int Control = 0;
        int i = 0;
        for (i = 0; i < s.Length; i++)
        {
            bool founded = false;
            int k = 0;
            while (!founded && k < Seed.Length)
            {
                if (s[i] == 'K')
                {
                    output += ',';
                    founded = true;
                    Control++;
                }
                else if (s[i] == Seed[k])
                {
                    output += k;
                    founded = true;
                    Control++;
                }
                k++;
            }
           
        }
        if (Control == i)
        {
            return Convert.ToInt32(output);
        }
        else
        {
            return -1;
        }
    }
    public static double getScaleValue(string s)
    {
        string output = "";
        int Control = 0;
        int i;
        for (i = 0; i < s.Length; i++)
        {
            bool founded = false;
            int k = 0;
            while (!founded && k < Seed.Length)
            {
                if (s[i] == 'K')
                {
                    output += ',';
                    founded = true;
                    Control++;
                }
                else if (s[i] == Seed[k])
                {
                    output += k;
                    founded = true;
                    Control++;
                }
                k++;
            }
        }
        if (Control == i)
        {
            return Convert.ToDouble(output);
        }
        else
        {
            return -1;
        }
        
    }
    public void CreateMap()
    {
        CreateMap2.SetActive(true);
        CreateMap1.SetActive(false);
        MapSeedCode1.SetActive(false);
    }
    public void CreateMapWithSeed()
    {
        CreateMap1.SetActive(false);
        MapSeedCode1.SetActive(false);
        MapSeedCode2.SetActive(true);
    }
}
