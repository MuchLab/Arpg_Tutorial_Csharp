using Godot;
using System;

public partial class Bat : CharacterBody2D
{
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
