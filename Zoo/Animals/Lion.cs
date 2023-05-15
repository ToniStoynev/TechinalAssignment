namespace Zoo.Animals;

public class Lion : Animal
{
    public override bool IsAlive => HealthPoints >= 50;
}
