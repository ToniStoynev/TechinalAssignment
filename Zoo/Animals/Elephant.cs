namespace Zoo.Animals;

public class Elephant : Animal
{
    public bool CanWalk => HealthPoints >= 70;
}
