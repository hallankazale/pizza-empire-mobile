using PizzaEmpire.Core;
using PizzaEmpire.Player;
using UnityEngine;
namespace PizzaEmpire.Production {
 public sealed class HarvestZone:MonoBehaviour {
  [SerializeField] float interval=.55f; float next;
  void OnTriggerStay(Collider other){if(Time.time<next)return;if(!other.CompareTag("Player"))return;next=Time.time+interval;GameManager.Instance?.Inventory.TryAdd(ItemType.Wheat);}
 }
}