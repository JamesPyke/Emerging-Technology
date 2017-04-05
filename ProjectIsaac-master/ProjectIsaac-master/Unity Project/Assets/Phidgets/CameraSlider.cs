using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSlider : MonoBehaviour
{
    private PhidgetInterfaceKit phidgetInterfaceKit;
    //adding a minimum and maximum zoom so that the zoom stays within a comfortable range
    private const float kMinZoom = 60.0f;
    private const float kMaxZoom = 10.0f;


    void Start ()
	{
        phidgetInterfaceKit = PhidgetInterfaceKit.getInstance();
	}
	
    void Update()
    {
        //Scales down the phidget value to fit within the range given
        float sensorValue = phidgetInterfaceKit.getValue(1) / 16.7f;

        //Checks whether the sensor value is outside the resired range and locks it to either
        //the minimum or maximum range 
        if (sensorValue > kMinZoom)
        {
            sensorValue = kMinZoom;
        }
        else if (sensorValue < kMaxZoom)
        {
            sensorValue = kMaxZoom;
        }
    //Sets the camera's feild of view to the value of the sensor
    GetComponent<Camera>().fieldOfView = sensorValue;

	}
}
