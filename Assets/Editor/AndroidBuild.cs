#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
public static class AndroidBuild {
 public static void BuildApk(){
  Directory.CreateDirectory("Builds/Android");
  EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android,BuildTarget.Android);
  PlayerSettings.companyName="PizzaEmpire";
  PlayerSettings.productName="Pizza Empire";
  PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android,"com.pizzaempire.mobile");
  PlayerSettings.defaultInterfaceOrientation=UIOrientation.Portrait;
  var report=BuildPipeline.BuildPlayer(new[]{"Assets/Scenes/Main.unity"},"Builds/Android/PizzaEmpire.apk",BuildTarget.Android,BuildOptions.None);
  if(report.summary.result!=BuildResult.Succeeded)throw new System.Exception("Android build failed");
 }
}
#endif
