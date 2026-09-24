using UnityEngine;
namespace PizzaEmpire.Player {
 [RequireComponent(typeof(CharacterController))]
 public sealed class PlayerMover:MonoBehaviour {
  [SerializeField] float speed=4.5f; CharacterController controller; Vector2 input;
  void Awake()=>controller=GetComponent<CharacterController>();
  public void SetMoveInput(Vector2 value)=>input=Vector2.ClampMagnitude(value,1f);
  void Update(){var move=new Vector3(input.x,0f,input.y);controller.SimpleMove(move*speed);if(move.sqrMagnitude>.01f)transform.forward=Vector3.Slerp(transform.forward,move.normalized,12f*Time.deltaTime);}
 }
}