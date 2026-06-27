using Photon.Pun;
using UnityEngine.Events;

public class Interactable : MonoBehaviourPun, IInteractable
{
    public UnityEvent<NetPlayer> onPress;
    public void OnPress(Interactor interactor)
    {
        photonView.RPC(nameof(PressRpc), RpcTarget.AllBufferedViaServer, interactor.controller.MyNetPlayer.id);
    }

    [PunRPC]
    private void PressRpc(int senderId)
    {
        onPress?.Invoke(GameManager.instance.players[senderId]);
    }
}
