using PizzaEmpire.Core;
using UnityEngine;
namespace PizzaEmpire.Production {
 public sealed class SellCounter:MonoBehaviour {
  [SerializeField] int price=12;
  void OnTriggerStay(Collider other){if(!other.CompareTag("Player")||GameManager.Instance==null)return;var inv=GameManager.Instance.Inventory;if(inv.TryTake(ItemType.BakedPizza)){GameManager.Instance.Economy.Add(price);}}
 }
}