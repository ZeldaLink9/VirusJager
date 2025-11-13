using UnityEngine;
using UnityEngine.InputSystem;

public class G29InputLogger : MonoBehaviour
{
    private Joystick g29Wheel;

    void Start()
    {
        if (Joystick.all.Count > 0)
        {
            g29Wheel = Joystick.all[0];
            Debug.Log($"Joystick detected: {g29Wheel.name}");
        }
        else
        {
            Debug.LogError("No joystick detected!");
        }
    }

    void Update()
    {
        if (g29Wheel != null)
        {
            float steering = g29Wheel.stick.x.ReadValue(); // left=-1, right=1
            float gas = -g29Wheel.stick.y.ReadValue();     // invert to make pressed=1
           // float brake = -g29Wheel.stick.z.ReadValue();   // invert to make pressed=1

            Debug.Log($"Steering: {steering:F2}, Gas: {gas:F2}");
        }
    }
}