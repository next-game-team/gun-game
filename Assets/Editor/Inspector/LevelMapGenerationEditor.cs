using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelMapGenerator))]
public class LevelMapGenerationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    
        var script = (LevelMapGenerator) target;
        if(GUILayout.Button("Generate Map"))
        {
            script.GenerateMap();
        }
        if(GUILayout.Button("Recalculate distances"))
        {
            script.RecalculateDistances();
        }
    }
}