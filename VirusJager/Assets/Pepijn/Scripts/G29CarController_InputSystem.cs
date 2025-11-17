using UnityEngine;
using UnityEngine.InputSystem;

public class G29CarController_InputSystem : MonoBehaviour
{
    [Header("Car Settings")]
    public float maxSpeed = 10f;
    public float acceleration = 5f;
    public float steeringAngle = 45f;

    private float currentSpeed = 0f;
    private float steerValue;
    private float throttleValue;
    private float brakeValue;

    // Input actions (set in Inspector)
    public InputAction steerAction;
    public InputAction throttleAction;
    public InputAction brakeAction;

    void OnEnable()
    {
        steerAction.Enable();
        throttleAction.Enable();
        brakeAction.Enable();
    }

    void OnDisable()
    {
        steerAction.Disable();
        throttleAction.Disable();
        brakeAction.Disable();
    }

    void Update()
    {
        steerValue = steerAction.ReadValue<float>();
        throttleValue = throttleAction.ReadValue<float>();
        brakeValue = brakeAction.ReadValue<float>();

        // throttle en brake normaliseren (0–1)
        float targetSpeed = (throttleValue - brakeValue) * maxSpeed;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, steerValue * steeringAngle * Time.deltaTime);
    }
}
