using Godot;
using System;

public partial class PlayerRollState : CharacterState
{
    [Export] private float maxSpeed = 150;
    [Export] private float acceleration = 50;
    [Export] private PlayerIdleState idleState;
    public override void OnEnter()
    {
        ((AnimationNodeStateMachinePlayback)animationTree.Get(PARAMETER_PLAYBACK)).Travel("roll");
    }

    public override void StateProcess(double delta)
    {
        animationTree.Set("parameters/roll/blend_position", defaultDirection);
        character.Velocity = character.Velocity.MoveToward(maxSpeed * defaultDirection, acceleration);
    }

    public void _on_animation_tree_animation_finished(string animationName)
    {
        if (animationName.Contains("roll"))
            nextState = idleState;
    }
}
