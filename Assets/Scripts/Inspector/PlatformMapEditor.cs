﻿using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PlatformMap))]
public class PlatformMapEditor : Editor
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