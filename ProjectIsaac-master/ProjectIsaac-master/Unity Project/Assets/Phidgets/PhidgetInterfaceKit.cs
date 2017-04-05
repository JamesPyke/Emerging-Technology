using Phidgets;
using Phidgets.Events;

public class PhidgetInterfaceKit
{
    private static PhidgetInterfaceKit instance;
    private static InterfaceKit interfaceKit;
    //Creates an array of index values (0-7) as indexes for the I/O board
    private static readonly int[] sensorValues = new int[8];
    //Checks if an instance of the IF kit have been made, if not creates one
    public static PhidgetInterfaceKit getInstance()
    {
        if (instance == null)
        {
            instance = new PhidgetInterfaceKit();
        }
        return instance;
    }
    //Returns the index value on the I/O board
    public int getValue(int sensorIndex)
    {
        return sensorValues[sensorIndex];
    }
    //Initialises the IF kit and waits for sensor change
    private PhidgetInterfaceKit()
    {
        interfaceKit = new InterfaceKit();

        interfaceKit.SensorChange += onSensorChange;

        interfaceKit.open();

        interfaceKit.waitForAttachment(1000);
    }
    //Checks for sensor change and returns the value to the IF kit
    private static void onSensorChange(object sender, SensorChangeEventArgs e)
    {
        sensorValues[e.Index] = e.Value;
    }

}
