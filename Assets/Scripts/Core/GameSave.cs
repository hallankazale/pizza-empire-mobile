using UnityEngine;
namespace PizzaEmpire.Core {
 public static class GameSave {
  const string MoneyKey="pizza_empire_money";
  public static void SaveMoney(int money){PlayerPrefs.SetInt(MoneyKey,money);PlayerPrefs.Save();}
  public static int LoadMoney()=>PlayerPrefs.GetInt(MoneyKey,0);
 }
}