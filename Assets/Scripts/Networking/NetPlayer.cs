using Photon.Pun;

public class NetPlayer : MonoBehaviourPun
{
    public int id { get; private set; }

    private void Start()
    {
        id = photonView.OwnerActorNr;
        GameManager.instance.players.Add(id, this);
    }
}
