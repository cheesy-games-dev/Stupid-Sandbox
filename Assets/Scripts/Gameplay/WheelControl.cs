using UnityEngine;

public class WheelControl : MonoBehaviour
{
    public WheelCollider WheelCollider { get; set; }

    // Create properties for the CarControl script
    // (You should enable/disable these via the 
    // Editor Inspector window)
    public bool steerable;
    public bool motorized;

    private void Start()
    {
        WheelCollider = GetComponent<WheelCollider>();
    }
}
