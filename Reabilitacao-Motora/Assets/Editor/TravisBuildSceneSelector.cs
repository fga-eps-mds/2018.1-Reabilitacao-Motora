using UnityEngine;
using System.Collections;
using UnityEditor;

public class TravisBuildSceneSelector {
  public static void Perform() {
    var sceneArray = new EditorBuildSettingsScene[1];
    sceneArray[0] = new EditorBuildSettingsScene("Assets/Scenes/Menu.unity", true);
    EditorBuildSettings.scenes = sceneArray;
  }
}
