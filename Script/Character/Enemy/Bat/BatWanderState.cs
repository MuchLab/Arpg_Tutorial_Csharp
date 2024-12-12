using Godot;
using System;

public partial class BatWanderState : CharacterState
{
    [Export] private float wanderRange = 32;
    [Export] private float maxSpeed = 75;
    [Export] private float acceleration = 25;
    [Export] private BatIdleState idleState;
    private Vector2 targetPosition;
    public override void OnEnter()
    {
        ((AnimationNodeStateMachinePlayback)animationTree.Get(PARAMETER_PLAYBACK)).Travel("fly");
        targetPosition = GenerateTargetPosition();
    }
    public override void StateProcess(double delta)
    {
        var targetDirection = character.GlobalPosition.DirectionTo(targetPosition);
        if (character.GlobalPosition.DistanceSquaredTo(targetPosition) > 4)
            character.Velocity = character.Velocity.MoveToward(targetDirection * maxSpeed, acceleration);
        else
            nextState = idleState;
    }
    private Vector2 GenerateTargetPosition()
    {
        float randomRange = (float)GD.RandRange(-wanderRange, wanderRange);
        return ((Bat)character).originPosition+ new Vector2(-randomRange, randomRange);
    }
}
