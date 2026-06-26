using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    public PlayerInput input;
    [SerializeField] private Transform fpsCamera;
    [SerializeField] private Transform tpsCamera;
    private bool isFirstPerson = true;

    private void Update() {
        input.camera.transform.position = isFirstPerson ? fpsCamera.position : tpsCamera.position;
        input.camera.transform.rotation = isFirstPerson ? fpsCamera.rotation : tpsCamera.rotation;
    }

    public void OnChangeCamera()
    {
        isFirstPerson = !isFirstPerson;
    }
}
