using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ModelLoader))]
public class ModelLoaderEditor : Editor
{
    ModelLoader loader;
    void OnEnable() {
      loader = target as ModelLoader;
    }
  public override void OnInspectorGUI() {
    DrawDefaultInspector();
    if (GUILayout.Button("Load1")) {
      loader.LoadFile1();
    }
    if (GUILayout.Button("Load2")) {
      loader.LoadFile2();
    }

  }
}
