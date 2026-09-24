using UnityEngine;
namespace PizzaEmpire.CameraSystem {
 public sealed class IsometricCamera:MonoBehaviour {
  [SerializeField] Transform target; [SerializeField] Vector3 offset=new Vector3(8f,11f,-8f); [SerializeField] float smooth=8f;
  void LateUpdate(){if(!target)return;transform.position=Vector3.Lerp(transform.position,target.position+offset,1f-Mathf.Exp(-smooth*Time.deltaTime));transform.LookAt(target.position+Vector3.up*.7f);}
 }
}