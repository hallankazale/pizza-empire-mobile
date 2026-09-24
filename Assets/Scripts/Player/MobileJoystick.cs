using UnityEngine;
using UnityEngine.EventSystems;
namespace PizzaEmpire.Player {
 public sealed class MobileJoystick:MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler {
  [SerializeField] RectTransform handle; [SerializeField] PlayerMover player; [SerializeField] float radius=90f;
  RectTransform area;
  void Awake()=>area=(RectTransform)transform;
  public void OnPointerDown(PointerEventData e)=>OnDrag(e);
  public void OnDrag(PointerEventData e){if(!RectTransformUtility.ScreenPointToLocalPointInRectangle(area,e.position,e.pressEventCamera,out var p))return;var v=Vector2.ClampMagnitude(p/radius,1f);if(handle)handle.anchoredPosition=v*radius;if(player)player.SetMoveInput(v);}
  public void OnPointerUp(PointerEventData e){if(handle)handle.anchoredPosition=Vector2.zero;if(player)player.SetMoveInput(Vector2.zero);}
 }
}