using UnityEngine;

[ExecuteInEditMode]
public class ModCursorArrow : MonoBehaviour
    {       
        public ModCursor modCursor;
        public bool scaleInsteadOfPosition = false;

        public Vector3Int addition;

        void Start(){
            modCursor = GetComponentInParent<ModCursor>();
        }

        private void OnMouseDown(){
            if(scaleInsteadOfPosition){
                modCursor.ScaleObjectBy(addition.x, addition.y, addition.z);
            }
            else{
                modCursor.MoveObjectBy(addition.x, addition.y, addition.z);
            }
        }
    }
