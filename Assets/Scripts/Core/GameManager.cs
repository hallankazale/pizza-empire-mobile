using PizzaEmpire.Player;
using UnityEngine;
namespace PizzaEmpire.Core {
 public sealed class GameManager:MonoBehaviour {
  public static GameManager Instance{get;private set;}
  public Economy Economy{get;private set;}
  public CarryInventory Inventory{get;private set;}
  void Awake(){if(Instance!=null&&Instance!=this){Destroy(gameObject);return;}Instance=this;Economy=new Economy(GameSave.LoadMoney());Inventory=new CarryInventory(5);Economy.Changed+=GameSave.SaveMoney;}
  void OnDestroy(){if(Economy!=null)Economy.Changed-=GameSave.SaveMoney;}
 }
}