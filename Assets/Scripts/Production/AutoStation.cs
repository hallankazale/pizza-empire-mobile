using System.Collections;
using PizzaEmpire.Core;
using UnityEngine;
namespace PizzaEmpire.Production {
 public sealed class AutoStation:MonoBehaviour {
  [SerializeField] ItemType input=ItemType.Wheat; [SerializeField] int inputAmount=3;
  [SerializeField] ItemType output=ItemType.Dough; [SerializeField] int outputAmount=1; [SerializeField] float seconds=1.5f;
  bool busy;
  void OnTriggerStay(Collider other){if(busy||!other.CompareTag("Player")||GameManager.Instance==null)return;var inv=GameManager.Instance.Inventory;if(inv.Item!=input||inv.Count<inputAmount)return;StartCoroutine(Process(inv));}
  IEnumerator Process(PizzaEmpire.Player.CarryInventory inv){busy=true;if(inv.TryTake(input,inputAmount)){yield return new WaitForSeconds(seconds);inv.Replace(output,outputAmount);}busy=false;}
 }
}