using UnityEngine;

namespace MindlessMods{

    #if UNITY_EDITOR
    using UnityEditor;
        [CustomEditor(typeof(ModCS))]
        public class ModCursorSelect : Editor{
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ModCS targetScript = (ModCS)target;
            if(GUILayout.Button("Make ModCursor")){
                targetScript.gameObject.AddComponent<ModCursor>();
            }
            if(GUILayout.Button("Make ModCursorArrow")){
                targetScript.gameObject.AddComponent<ModCursorArrow>();
            }
        }
    }
    #endif
    public class ModCS : MonoBehaviour {
        [SerializeField]
        private const string text = "Choose which class to make";
    }
}

