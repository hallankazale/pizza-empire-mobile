using UnityEngine;
namespace PizzaEmpire.Core {
 public sealed class UpgradeZone:MonoBehaviour {
  [SerializeField] int cost=50; [SerializeField] GameObject unlockObject; bool unlocked;
  void OnTriggerEnter(Collider other){if(unlocked||!other.CompareTag("Player")||GameManager.Instance==null)return;if(GameManager.Instance.Economy.TrySpend(cost)){unlocked=true;if(unlockObject)unlockObject.SetActive(true);gameObject.SetActive(false);}}
 }
}