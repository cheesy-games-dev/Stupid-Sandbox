using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    public Transform camera;
    [SerializeField] private Transform fpsCamera;
    [SerializeField] private Transform tpsCamera;
    public bool IsFirstPerson { get; set; } = true;
    private void Update() {
        camera.position = IsFirstPerson?fpsCamera.position:tpsCamera.position;
        camera.rotation = IsFirstPerson ? fpsCamera.rotation : tpsCamera.rotation;
    }

    public void OnChangeCamera()
    {
        IsFirstPerson = !IsFirstPerson;
    }
}
