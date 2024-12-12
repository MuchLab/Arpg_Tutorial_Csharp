using Godot;
using System;

public partial class PlayerHurtState : CharacterState
{
    [Export] private float knockingbackSpeed = 150;
    [Export] private float friction = 150;
    [Export] private PlayerIdleState idleState;

    public override void StateProcess(double delta)
    {
        character.Velocity = character.Velocity.MoveToward(Vector2.Zero, friction * (float)delta);
        if (character.Velocity == Vector2.Zero)
            nextState = idleState;
    }
    public void _on_hurtbox_knockingback_character(Hurtbox hurtbox, CharacterBody2D hittingCharacter)
    {
        var direction = hittingCharacter.GlobalPosition.DirectionTo(character.GlobalPosition);
        character.Velocity = direction * knockingbackSpeed;
        EmitSignal(CharacterState.SignalName.InterruptState, this);
    }
}
