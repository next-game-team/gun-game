using UnityEditor;
using UnityEngine;

namespace Editor.Inspector
{
    [CustomEditor(typeof(SeparableImage))]
    public class SeparableImageEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        
            var script = (SeparableImage) target;
            if(GUILayout.Button("Init"))
            {
                script.Init();
            }
            if(GUILayout.Button("Next"))
            {
                script.Increase(1);
            }
            if(GUILayout.Button("Previous"))
            {
                script.Decrease(1);
            }
        }
    }
}