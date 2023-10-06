using Godot;
using System;

public partial class BatResumeState : CharacterState
{
    [Export] private float maxSpeed = 75;
    [Export] private float acceleration = 25;
    [Export] private BatIdleState idleState;
    public override void OnEnter()
    {
        ((AnimationNodeStateMachinePlayback)animationTree.Get(PARAMETER_PLAYBACK)).Travel("fly");
    }
    public override void StateProcess(double delta)
    {
        var direction = character.GlobalPosition.DirectionTo(((Bat)character).originPosition);
        character.Velocity = character.Velocity.MoveToward(direction * maxSpeed, acceleration);
        if (character.GlobalPosition.DistanceSquaredTo(((Bat)character).originPosition) < 4) 
        {
            character.GlobalPosition = ((Bat)character).originPosition;
            nextState = idleState;
        }
    }
}
