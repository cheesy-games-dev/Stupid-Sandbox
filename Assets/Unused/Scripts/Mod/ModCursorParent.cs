using UnityEngine;
using MindlessMods;
public class ModCursor : MonoBehaviour
    {       
        public ModGameObject selectedModObject;

        void LateUpdate(){
            foreach(Transform tr in GetComponentInChildren<Transform>()){
                    if(tr != this.transform){
                        tr.gameObject.SetActive(selectedModObject != null);
                    }
                }
            if(selectedModObject == null) {               
                return;
            }
            transform.position = selectedModObject.transform.position;
            transform.rotation = selectedModObject.transform.rotation;
            transform.localScale = selectedModObject.transform.localScale;
        }

        public void MoveObjectBy(int x, int y, int z){
            if(selectedModObject == null) return;
            Vector3 v = new Vector3(x, y, z);
            if(selectedModObject.GetRigidbody() != null) selectedModObject.GetRigidbody().position += v;
            else selectedModObject.transform.position += v;
        }

        public void ScaleObjectBy(int x, int y, int z){
            if(selectedModObject == null) return;
            Vector3 v = new Vector3(x, y, z);
            selectedModObject.transform.localScale += v;
        }

    }