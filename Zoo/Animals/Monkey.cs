using System.Runtime.CompilerServices;

namespace Zoo.Animals;

public class Monkey : Animal
{
    public override bool IsAlive => HealthPoints >= 40;
}
