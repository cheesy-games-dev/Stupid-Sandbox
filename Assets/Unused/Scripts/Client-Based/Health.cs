using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Health : MonoBehaviourPun, IPunObservable
{
    public float health = 50f;
    public UnityEvent<float> onDamage;
    public UnityEvent onFlatline;
    public void Damage(float damage)
    {
        photonView.RPC(nameof(DamageRpc), RpcTarget.All, damage);
    }

    [PunRPC]
    private void DamageRpc(float damage)
    {
        health -= damage;
        onDamage.Invoke(damage);
        if (onFlatline != null && health < 1) onFlatline.Invoke();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            stream.SendNext(health);
        }
        else {
            health = (float)stream.ReceiveNext();
        }
    }
}
