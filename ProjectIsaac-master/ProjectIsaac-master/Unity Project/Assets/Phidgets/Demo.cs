using System.Collections;
using UnityEngine;

public class Demo : MonoBehaviour
{
    private PhidgetInterfaceKit phidgetInterfaceKit;

    private bool ready;
    public GameObject grenade;

    public Transform grenadeSpawnPosition;

    private void Start()
    {
        //Creating a new instance of the IF kit
        phidgetInterfaceKit = PhidgetInterfaceKit.getInstance();
        ready = true;
    }

    private void Update()
    {
        //Asking for the value and specify the index
        if(phidgetInterfaceKit.getValue(0) <= 500 && ready)
        {
            //Creating a grenade gameObject when the sensor registers a change
            Instantiate(grenade, grenadeSpawnPosition.position, grenadeSpawnPosition.rotation);
            ready = false;
            StartCoroutine(coolDown());
        }
    }
    //Give the grenade a cooldown timer to stop grenade spam
    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(1.0f);
        ready = true;
    }

}
