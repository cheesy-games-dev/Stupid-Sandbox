using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetManager : MonoBehaviourPunCallbacks
{
    public bool createRoomOnStart = true;
    private void Start()
    {
        CreateRoom(16);
    }
    public void CreateRoom(int maxPlayers, bool joinable = true, bool isPublic = true)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = maxPlayers;
        options.IsOpen = joinable;
        options.IsVisible = isPublic;
        PhotonNetwork.CreateRoom(Random.Range(0, ushort.MaxValue).ToString());
    }

    public override void OnCreatedRoom()
    {
        var gameManager = PhotonNetwork.InstantiateRoomObject(ActiveData.Instance.gameManagerAddress, Vector3.zero, Quaternion.identity);
    }
}
