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
    private void Start()
    {
        NetManager.instance.SpawnPlayer(this);
    }
    private void Update()
    {
        if (MyNetPlayer)
        {
            MyNetPlayer.transform.position = transform.position;
            MyNetPlayer.transform.rotation = transform.rotation;
            foreach (var collider in MyNetPlayer.GetComponentsInChildren<Collider>())
            {
                Physics.IgnoreCollision(this.collider, collider, true);
            }
        }     
    }
}
