using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public NetPlayer MyNetPlayer { get; set; }
    public Pause MyPause { get; set; }
    public SpawnMenu MySpawnMenu { get; set; }
    public PlayerUI MyUI { get; set; }

    public PlayerMovement movement;
    public CameraControls camera;
    public PlayerInput input;
    public Collider collider;
    public Transform orientation;
    private void Start()
    {
        GameManager.instance.SpawnPlayer(this);
    }
    private void Update()
    {
        if (MyNetPlayer)
        {
            MyNetPlayer.orientation.position = orientation.position;
            MyNetPlayer.orientation.rotation = orientation.rotation;
            foreach (var collider in MyNetPlayer.GetComponentsInChildren<Collider>())
            {
                Physics.IgnoreCollision(this.collider, collider, true);
            }
        }     
    }
}
