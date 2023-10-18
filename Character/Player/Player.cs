using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Signal] public delegate void PlayerHealthChangedEventHandler(int currentHealth);
    [Signal] public delegate void PlayerDeathEventHandler();

    private int currentHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set 
        { 
            currentHealth = value <= 0 ? 0 : value;
            if (currentHealth <= 0)
                EmitSignal(SignalName.PlayerDeath);
            EmitSignal(SignalName.PlayerHealthChanged, currentHealth);
        }
    }

    public override void _Ready()
    {
    }
    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }
}