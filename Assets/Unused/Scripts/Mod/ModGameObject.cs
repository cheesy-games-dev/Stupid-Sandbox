using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindlessMods {
    public class ModGameObject : MonoBehaviour {
        
        public Rigidbody GetRigidbody(){
            Rigidbody rb = GetComponent<Rigidbody>();
            if(rb != null) return rb;
            else return null;
        }

        private void Awake() {
            if(FindObjectOfType<ModSaveSystem>() == null) {
                Destroy(this);
            }
        }

        private void OnDestroy() {
            ModSaveSystem.objects.Remove(this);
        }
        void Start () {
            ModSaveSystem.objects.Add(this);
        }

        void Update(){
            foreach(Collider co in GetComponentsInChildren<Collider>()){
                co.hasModifiableContacts = true;
            }
        }

        private void OnMouseDown(){
            FindAnyObjectByType<ModCursor>().selectedModObject = this;
        }
    }
}

