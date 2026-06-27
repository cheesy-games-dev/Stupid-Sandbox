using Photon.Pun;
using UnityEngine;

public class NetPlayer : MonoBehaviourPun
{
    public int id { get; private set; }
    public Transform orientation;
    private void Start()
    {
        id = photonView.OwnerActorNr;
        GameManager.instance.players.Add(id, this);
    }
}
