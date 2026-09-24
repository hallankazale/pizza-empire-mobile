using System;
namespace PizzaEmpire.Core {
 public sealed class Economy {
  public int Money { get; private set; }
  public event Action<int> Changed;
  public Economy(int initialMoney=0)=>Money=Math.Max(0,initialMoney);
  public void Add(int amount){if(amount<=0)return;Money+=amount;Changed?.Invoke(Money);}
  public bool TrySpend(int amount){if(amount<=0||Money<amount)return false;Money-=amount;Changed?.Invoke(Money);return true;}
 }
}