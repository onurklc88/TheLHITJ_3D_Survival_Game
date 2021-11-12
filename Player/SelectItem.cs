using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    [SerializeField] private Camera cam1;

    RaycastHit hit;

    private void Update()
    {
        
        Ray ray = cam1.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));


        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Select")
            {
                Text.SetActive(true);
            }
            else
            {
                Text.SetActive(false);
            }
        }
        else
        {
            Text.SetActive(false);
        }
    }
}
