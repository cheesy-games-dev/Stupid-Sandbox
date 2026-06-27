using UnityEngine;

public class TransformToWheel : MonoBehaviour
{
    public WheelCollider wheel;

    private void Update()
    {
        wheel.GetWorldPose(out Vector3 position, out Quaternion rotation);
        transform.position = position;
        transform.rotation = rotation;
    }
}
