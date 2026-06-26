using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class NetManager : MonoBehaviour
{
    public static NetManager instance;
    public readonly Dictionary<int, NetPlayer> netPlayers = new();
    public string remotePlayerAddress;
    private void Awake()
    {
        instance = this;
    }

    public void SpawnPlayer(PlayerController controller)
    {
        var netPlayer = PhotonNetwork.Instantiate(remotePlayerAddress, controller.transform.position, controller.transform.rotation);
        controller.MyNetPlayer = netPlayer.GetComponent<NetPlayer>();
    }
}
