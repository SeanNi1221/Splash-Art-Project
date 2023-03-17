using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriLibCore;
using TriLibCore.General;
public class ModelLoader : MonoBehaviour {
  public Object file1;
  public string path1;
  public GameObject go1;

  public Object file2;
  public string path2;
  public GameObject go2;
  void OnValidate() {
    if (file1) {
      path1 = UnityEditor.AssetDatabase.GetAssetPath(file1);
    }
    if (file2) {
      path2 = UnityEditor.AssetDatabase.GetAssetPath(file2);
    }
  }
  public void LoadFile1() {
    var assetLoaderOptions = AssetLoader.CreateDefaultLoaderOptions();
    assetLoaderOptions.ApplyGammaCurveToMaterialColors = false;
    assetLoaderOptions.LoadTexturesAsSRGB = false;
    AssetLoader.LoadModelFromFile(path1,
                                  OnLoad1,
                                  null,
                                  null,
                                  null,
                                  null,
                                  assetLoaderOptions
    );
  }
  private void OnLoad1(AssetLoaderContext assetLoaderContext) {
  go1 = assetLoaderContext.RootGameObject;
}

  public void LoadFile2() {
    var assetLoaderOptions = AssetLoader.CreateDefaultLoaderOptions();
    assetLoaderOptions.ApplyGammaCurveToMaterialColors = false;
    assetLoaderOptions.LoadTexturesAsSRGB = false;
    AssetLoader.LoadModelFromFile(path2,
                                  OnLoad2,
                                  null,
                                  null,
                                  null,
                                  null,
                                  assetLoaderOptions
    );
  }
  private void OnLoad2(AssetLoaderContext assetLoaderContext) {
    go2 = assetLoaderContext.RootGameObject;
  }
}
