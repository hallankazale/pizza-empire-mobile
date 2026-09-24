using PizzaEmpire.Player;
namespace PizzaEmpire.Production {
 public static class ProductionRules {
  public static bool TryProcess(CarryInventory inventory,Recipe recipe){if(!inventory.TryTake(recipe.Input,recipe.InputAmount))return false;inventory.Replace(recipe.Output,recipe.OutputAmount);return true;}
 }
}