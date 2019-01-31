using UnityEditor;
using UnityEngine;

namespace Editor.Inspector
{
    [CustomEditor(typeof(PlatformMapGenerator))]
    public class PlatformMapGenerationEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        
            var script = (PlatformMapGenerator) target;
            if(GUILayout.Button("Generate Map"))
            {
                script.GenerateMap();
            }
        }
    }
}