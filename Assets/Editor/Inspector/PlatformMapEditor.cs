using UnityEditor;
using UnityEngine;

namespace Editor.Inspector
{
    [CustomEditor(typeof(PlatformMap))]
    public class PlatformMapEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        
            var script = (PlatformMap) target;
            if(GUILayout.Button("Find Map"))
            {
                script.FindMap();
            }
        }
    }
}