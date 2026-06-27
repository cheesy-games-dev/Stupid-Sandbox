using Photon.Pun;
using System.Collections.Generic;
public class GameManager : MonoBehaviourPun
{
    public static GameManager instance;
    public readonly Dictionary<int, PlayerController> localPlayers = new();
    public readonly Dictionary<int, NetPlayer> players = new();
    public string networkPlayerAddress;
    public PlayerUI uiPrefab;

    private void Start()
    {
        instance = this;
    }

    public void SpawnPlayer(PlayerController controller)
    {
        localPlayers.Add(controller.input.playerIndex, controller);
        var netPlayer = PhotonNetwork.Instantiate(networkPlayerAddress, controller.transform.position, controller.transform.rotation);
        controller.MyNetPlayer = netPlayer.GetComponent<NetPlayer>();
        controller.MyUI = Instantiate(uiPrefab);
    }
}
