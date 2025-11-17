using UnityEngine;
using System.Runtime.InteropServices;

public class LogitechForceFeedback : MonoBehaviour
{
    [DllImport("LogitechSteeringWheelEnginesWrapper")]
    private static extern bool LogiSteeringInitialize(bool ignoreXInputControllers);

    [DllImport("LogitechSteeringWheelEnginesWrapper")]
    private static extern void LogiSteeringShutdown();

    [DllImport("LogitechSteeringWheelEnginesWrapper")]
    private static extern bool LogiUpdate();

    [DllImport("LogitechSteeringWheelEnginesWrapper")]
    private static extern bool LogiIsConnected(int index);

    [DllImport("LogitechSteeringWheelEnginesWrapper")]
    private static extern void LogiPlaySpringForce(int index, int offsetPercentage, int saturationPercentage, int coefficientPercentage);

    [DllImport("LogitechSteeringWheelEnginesWrapper")]
    private static extern void LogiStopSpringForce(int index);

    void Start()
    {
        LogiSteeringInitialize(false);
    }

    void Update()
    {
        LogiUpdate();

        if (LogiIsConnected(0))
        {
            // Voorbeeld: lichte weerstand rond middenstand
            int offset = 0;
            int saturation = 50;
            int coefficient = 50;
            LogiPlaySpringForce(0, offset, saturation, coefficient);
        }
    }

    void OnApplicationQuit()
    {
        LogiStopSpringForce(0);
        LogiSteeringShutdown();
    }
}
