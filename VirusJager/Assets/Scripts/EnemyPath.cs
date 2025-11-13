using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public Transform[] waypoints;

    private void Awake()
    {
        if (waypoints.Length == 0)
            waypoints = GetComponentsInChildren<Transform>();
    }
}