using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceSensor : MonoBehaviour {

    private PhidgetInterfaceKit phidgetInterfaceKit;

    void Start () {
        phidgetInterfaceKit = PhidgetInterfaceKit.getInstance();
    }
	
	// Update is called once per frame
	void Update () {
		Debug.Log(phidgetInterfaceKit.getValue(2));
	}
}
