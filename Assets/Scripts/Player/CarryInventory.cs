using PizzaEmpire.Core;
namespace PizzaEmpire.Player {
 public sealed class CarryInventory {
  public ItemType Item{get;private set;}=ItemType.None;
  public int Count{get;private set;}
  public int Capacity{get;}
  public CarryInventory(int capacity=5)=>Capacity=capacity<1?1:capacity;
  public bool TryAdd(ItemType item,int amount=1){if(item==ItemType.None||amount<=0||Count+amount>Capacity)return false;if(Count>0&&Item!=item)return false;Item=item;Count+=amount;return true;}
  public bool TryTake(ItemType item,int amount=1){if(item!=Item||amount<=0||Count<amount)return false;Count-=amount;if(Count==0)Item=ItemType.None;return true;}
  public void Replace(ItemType item,int count){Item=count>0?item:ItemType.None;Count=count>0?System.Math.Min(count,Capacity):0;}
 }
}