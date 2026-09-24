using PizzaEmpire.Core;
namespace PizzaEmpire.Production {
 public readonly struct Recipe {
  public readonly ItemType Input,Output; public readonly int InputAmount,OutputAmount;
  public Recipe(ItemType input,int inputAmount,ItemType output,int outputAmount=1){Input=input;InputAmount=inputAmount;Output=output;OutputAmount=outputAmount;}
 }
}