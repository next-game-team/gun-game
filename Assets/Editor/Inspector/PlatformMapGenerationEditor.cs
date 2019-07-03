using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlatformMapGenerator))]
public class PlatformMapGenerationEditor : Editor
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