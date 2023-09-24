using Godot;
using System;

public partial class PlayerRunState : CharacterState
{
    [Export] private int maxSpeed = 125;
    [Export] private int acceleration = 25;
    [Export] private PlayerIdleState idleState;
    public override void OnEnter()
    {
        ((AnimationNodeStateMachinePlayback)animationTree.Get(PARAMETER_PLAYBACK)).Travel("run");
    }
    public override void StateProcess(double delta)
    {
        var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if(direction == Vector2.Zero)
        {
            nextState = idleState;
        }
        else
        {
            animationTree.Set("parameters/run/blend_position", direction);
            character.Velocity = character.Velocity.MoveToward(maxSpeed * direction, acceleration);
            defaultDirection = direction;
        }
    }
}
