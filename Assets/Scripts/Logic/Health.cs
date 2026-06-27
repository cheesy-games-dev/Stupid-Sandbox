using Photon.Pun;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Health : MonoBehaviourPun, IPunObservable, IDamageable
{
    [FormerlySerializedAs("health")]
    public float startingHealth = 50;
    public UnityEvent<float> onDamage;
    public UnityEvent onFlatline;
    public float CurrentHealth { get; private set; }
    public bool Ded { get; private set; } = false;

    void Start()
    {
        CurrentHealth = startingHealth;
        Ded = false;
    }

    public void TakeDamage(float damage)
    {
        photonView.RPC(nameof(DamageRpc), RpcTarget.All, damage);
    }

    [PunRPC]
    private void DamageRpc(float damage)
    {
        CurrentHealth -= damage;
        if(onDamage != null) onDamage?.Invoke(damage);
        if (onFlatline != null && CurrentHealth < 1) {
            Ded = true;
            onFlatline?.Invoke();
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            stream.SendNext(CurrentHealth);
        }
        else {
            CurrentHealth = (float)stream.ReceiveNext();
        }
    }
}
