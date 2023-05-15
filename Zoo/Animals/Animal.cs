namespace Zoo.Animals;

public abstract class Animal
{
    public int HealthPoints { get; set; } = 100;

    public virtual bool IsAlive { get; set; } = true;
}
