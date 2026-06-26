using Photon.Pun;
using UnityEngine;

public class NetPlayer : MonoBehaviourPun
{
    public int id { get; private set; }

    private void Start()
    {
        id = photonView.OwnerActorNr;
        NetManager.instance.netPlayers.Add(id, this);
    }
}
