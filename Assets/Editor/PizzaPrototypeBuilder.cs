#if UNITY_EDITOR
using PizzaEmpire.CameraSystem;
using PizzaEmpire.Core;
using PizzaEmpire.Player;
using PizzaEmpire.Production;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class PizzaPrototypeBuilder {
 [MenuItem("Pizza Empire/Build Prototype Scene")]
 public static void Build(){
  var s=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
  new GameObject("GameManager").AddComponent<GameManager>();
  var floor=GameObject.CreatePrimitive(PrimitiveType.Plane);floor.name="Restaurant Floor";floor.transform.localScale=new Vector3(2.8f,1,2.8f);
  var p=GameObject.CreatePrimitive(PrimitiveType.Capsule);p.name="Player";p.tag="Player";p.transform.position=new Vector3(0,1,0);Object.DestroyImmediate(p.GetComponent<CapsuleCollider>());p.AddComponent<CharacterController>();p.AddComponent<PlayerMover>();
  var cam=new GameObject("Isometric Camera");var c=cam.AddComponent<Camera>();c.orthographic=true;c.orthographicSize=8;cam.AddComponent<IsometricCamera>();cam.transform.position=new Vector3(8,11,-8);
  MakeZone("Wheat Field",new Vector3(-6,.5f,4),new Vector3(4,1,4),typeof(HarvestZone));
  MakeZone("Mill",new Vector3(-2,.5f,4),new Vector3(2,1,2),typeof(AutoStation));
  MakeStation("Prep",new Vector3(2,.5f,4),ItemType.Dough,1,ItemType.RawPizza,1,1f);
  MakeStation("Oven",new Vector3(5,.5f,1),ItemType.RawPizza,1,ItemType.BakedPizza,1,2f);
  MakeZone("Counter",new Vector3(5,.5f,-3),new Vector3(3,1,2),typeof(SellCounter));
  var light=new GameObject("Sun");var dl=light.AddComponent<Light>();dl.type=LightType.Directional;dl.intensity=1.2f;light.transform.rotation=Quaternion.Euler(50,-30,0);
  EditorSceneManager.SaveScene(s,"Assets/Scenes/Main.unity");
  EditorBuildSettings.scenes=new[]{new EditorBuildSettingsScene("Assets/Scenes/Main.unity",true)};
  Debug.Log("Pizza Empire prototype scene created.");
 }
 static GameObject MakeZone(string n,Vector3 pos,Vector3 scale,System.Type t){var g=GameObject.CreatePrimitive(PrimitiveType.Cube);g.name=n;g.transform.position=pos;g.transform.localScale=scale;var col=g.GetComponent<BoxCollider>();col.isTrigger=true;g.AddComponent(t);return g;}
 static void MakeStation(string n,Vector3 pos,ItemType input,int ia,ItemType output,int oa,float sec){var g=MakeZone(n,pos,new Vector3(2,1,2),typeof(AutoStation));var so=new SerializedObject(g.GetComponent<AutoStation>());so.FindProperty("input").enumValueIndex=(int)input;so.FindProperty("inputAmount").intValue=ia;so.FindProperty("output").enumValueIndex=(int)output;so.FindProperty("outputAmount").intValue=oa;so.FindProperty("seconds").floatValue=sec;so.ApplyModifiedPropertiesWithoutUndo();}
}
#endif
