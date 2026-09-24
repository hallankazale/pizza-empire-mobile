using NUnit.Framework;
using PizzaEmpire.Core;
using PizzaEmpire.Player;
using PizzaEmpire.Production;
public class CarryInventoryTests {
 [Test] public void InventoryRejectsMixedItems(){var i=new CarryInventory(5);Assert.IsTrue(i.TryAdd(ItemType.Wheat,3));Assert.IsFalse(i.TryAdd(ItemType.Dough));}
 [Test] public void MillConvertsThreeWheatToDough(){var i=new CarryInventory(5);i.TryAdd(ItemType.Wheat,3);Assert.IsTrue(ProductionRules.TryProcess(i,new Recipe(ItemType.Wheat,3,ItemType.Dough)));Assert.AreEqual(ItemType.Dough,i.Item);Assert.AreEqual(1,i.Count);}
}
