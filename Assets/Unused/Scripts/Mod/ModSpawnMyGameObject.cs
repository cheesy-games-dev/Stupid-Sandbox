using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

namespace MindlessMods {
    public class ModSpawnMyGameObject : MonoBehaviour {

        public Transform spawnPostion;
        public Transform objectsHolder;

        public string extraText;
        public TMP_Text objectsHolderCounter;

        private void Update() {
            if(objectsHolderCounter != null) {
                objectsHolderCounter.text = (extraText + " " + objectsHolder.childCount).ToString();
            }
        }

        public void SpawnMyGameObject(GameObject myGameObject) {
            if(!PhotonNetwork.InRoom) return;
            GameObject go = PhotonNetwork.Instantiate(myGameObject.name, spawnPostion.position, Quaternion.identity).gameObject;
            if(!go) return;
            go.transform.parent = objectsHolder;
            go.transform.localScale = objectsHolder.lossyScale;
        }
    }
}

