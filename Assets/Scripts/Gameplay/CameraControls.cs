using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    public Transform camera;
    [SerializeField] private Transform backCamera;
    [SerializeField] private Transform frontCamera;
    public bool IsBackCamera { get; set; } = true;
    private void Update() {
        camera.position = IsBackCamera? backCamera.position: frontCamera.position;
        camera.rotation = IsBackCamera ? backCamera.rotation : frontCamera.rotation;
    }

    public void OnChangeCamera()
    {
        IsBackCamera = !IsBackCamera;
    }
}
