using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashlight : MonoBehaviour
{
    public Slider batterylife;
    Light flight;
    bool ison;
    // Start is called before the first frame update
    void Start()
    {
        flight = GetComponent<Light>();
        flight.enabled = false;
    }
    public void buttonpressed()
    {
        if (!ison)
        {
            ison = true;
        }
        else
        {
            ison = false;
        }
        if (ison && !flight.enabled)
        {
            flight.enabled = true;
        }
        if (!ison && flight.enabled)
        {
            flight.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flight.enabled)
        {
            StartCoroutine(decreasebattery());
        }
        if(!flight.enabled)
        {
            StartCoroutine(increasebattery());
        }
        if(batterylife.value<=0)
        {
            flight.enabled = false;
            ison = false;
            StartCoroutine(increasebattery());
        }
    }
    IEnumerator decreasebattery()
    {
        if(batterylife.value!=0)
        {
            batterylife.value-=0.5f;
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(60);
        }
       // StartCoroutine(decreasebattery());
    }
    IEnumerator increasebattery()
    {
        batterylife.value+=2;
        if(batterylife.value>=batterylife.maxValue)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        //StartCoroutine(increasebattery());
    }
}
