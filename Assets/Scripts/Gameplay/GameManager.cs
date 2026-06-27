using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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
    public PlayerController GetLocalPlayerFromNetPlayer(int playerId)
    {
        return GetLocalPlayerFromNetPlayer(players[playerId]);
    }
    public PlayerController GetLocalPlayerFromNetPlayer(NetPlayer player)
    {
        foreach (var localPlayer in localPlayers.Values)
        {
            if(localPlayer.MyNetPlayer ==  player) return localPlayer;
        }
        return null;
    }
}
