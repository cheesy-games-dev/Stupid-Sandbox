using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviourPun, IInteractable
{

    public UnityEvent<NetPlayer> onPress;
    public UnityEvent<NetPlayer> onRelease;

    public void OnPress(Interactor interactor)
    {
        photonView.RPC(nameof(PressRpc), RpcTarget.AllBufferedViaServer, interactor.controller.MyNetPlayer.id);
    }

    public void OnRelease(Interactor interactor)
    {
        photonView.RPC(nameof(ReleaseRpc), RpcTarget.AllBufferedViaServer, interactor.controller.MyNetPlayer.id);
    }

    [PunRPC]
    private void PressRpc(int senderId)
    {
        onPress?.Invoke(NetManager.instance.netPlayers[senderId]);
    }
    [PunRPC]
    private void ReleaseRpc(int senderId)
    {
        onRelease?.Invoke(NetManager.instance.netPlayers[senderId]);
    }
}
