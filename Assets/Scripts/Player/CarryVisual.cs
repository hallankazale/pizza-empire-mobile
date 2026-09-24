using PizzaEmpire.Core;
using UnityEngine;
namespace PizzaEmpire.Player {
 public sealed class CarryVisual:MonoBehaviour {
  [SerializeField] Transform stackRoot;
  public void Refresh(ItemType item,int count){
   if(!stackRoot)return;for(int i=stackRoot.childCount-1;i>=0;i--)Destroy(stackRoot.GetChild(i).gameObject);
   for(int i=0;i<count;i++){var g=GameObject.CreatePrimitive(PrimitiveType.Cube);g.name=item.ToString();g.transform.SetParent(stackRoot,false);g.transform.localScale=new Vector3(.45f,.12f,.45f);g.transform.localPosition=new Vector3(0,i*.14f,0);}
  }
 }
}