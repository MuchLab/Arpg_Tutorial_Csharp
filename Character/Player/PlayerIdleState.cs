using Godot;
using System;

public partial class PlayerIdleState : CharacterState
{
    [Export] private int friction = 10;
    [Export] private PlayerRunState runState;
    public override void OnEnter()
    {
        ((AnimationNodeStateMachinePlayback)animationTree.Get(PARAMETER_PLAYBACK)).Travel("idle");
    }
    public override void StateProcess(double delta)
    {
        var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction == Vector2.Zero)
        {
            animationTree.Set("parameters/idle/blend_position", defaultDirection);
            character.Velocity = character.Velocity.MoveToward(Vector2.Zero, friction);
        }
        else
            nextState = runState;
    }
}
