using Godot;

public partial class Bat : CharacterBody2D
{
    [Signal] public delegate void BatHealthChangedEventHandler(int currentHealth);
    [Signal] public delegate void BatDeathEventHandler();

    [Export] private int currentHealth = 100;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value <= 0 ? 0 : value;
            if (currentHealth <= 0)
                EmitSignal(SignalName.BatDeath);
            EmitSignal(SignalName.BatHealthChanged, currentHealth);
        }
    }

    public Vector2 originPosition;
    public Sprite2D sprite;
    public override void _Ready()
    {
        originPosition = GlobalPosition;
        sprite = GetNode<Sprite2D>("Sprite2D");
    }
    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }
}
