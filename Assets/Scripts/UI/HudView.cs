using PizzaEmpire.Core;
using TMPro;
using UnityEngine;
namespace PizzaEmpire.UI {
 public sealed class HudView:MonoBehaviour {
  [SerializeField] TMP_Text moneyText; [SerializeField] TMP_Text carryText;
  void Update(){if(GameManager.Instance==null)return;if(moneyText)moneyText.text="$ "+GameManager.Instance.Economy.Money;if(carryText){var i=GameManager.Instance.Inventory;carryText.text=i.Item+" "+i.Count+"/"+i.Capacity;}}
 }
}