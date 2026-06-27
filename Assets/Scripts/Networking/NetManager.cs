using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetManager : MonoBehaviourPunCallbacks
{
    public bool createRoomOnStart = true;
    private void Start()
    {
        PhotonNetwork.OfflineMode = true;
        if (PhotonNetwork.ConnectUsingSettings())
        {
            if (createRoomOnStart) CreateRoom(16);
        }
    }
    public void CreateRoom(int maxPlayers, bool joinable = true, bool isPublic = true)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = maxPlayers;
        options.IsOpen = joinable;
        options.IsVisible = isPublic;
        var code = Random.Range(0, ushort.MaxValue).ToString();
        PhotonNetwork.CreateRoom(code, options);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        PhotonNetwork.InstantiateRoomObject(ActiveData.Instance.gameManagerAddress, Vector3.zero, Quaternion.identity);
    }
}
