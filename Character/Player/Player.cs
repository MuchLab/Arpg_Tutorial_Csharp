using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] private float maxSpeed = 150;
    [Export] private float acceleration = 25;
    [Export] private float friction = 50;
    private AnimationPlayer animationPlayer;
    private Vector2 defaultDirection;

    public override void _Ready()
    {
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public override void _PhysicsProcess(double delta)
    {
        var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
            Velocity = Velocity.MoveToward(maxSpeed * direction, acceleration);
        else
            Velocity = Velocity.MoveToward(Vector2.Zero, friction);
        bool isPlayY = false;
        //Animation
        if (direction.X > 0)
        {
            animationPlayer.Play("run_right");
            isPlayY = false;
        }
        else if (direction.X < 0)
        {
            animationPlayer.Play("run_left");
            isPlayY = false;
        }
        else
            isPlayY = true;

        if (direction.Y > 0 && isPlayY)
            animationPlayer.Play("run_down");
        if (direction.Y < 0 && isPlayY)
            animationPlayer.Play("run_up");

        if (direction == Vector2.Zero)
        {
            if (defaultDirection.X > 0)
                animationPlayer.Play("idle_right");
            if (defaultDirection.X < 0)
                animationPlayer.Play("idle_left");
            if (defaultDirection.Y > 0)
                animationPlayer.Play("idle_down");
            if (defaultDirection.Y < 0)
                animationPlayer.Play("idle_up");
        }
        defaultDirection = direction;


        MoveAndSlide();
    }
}
