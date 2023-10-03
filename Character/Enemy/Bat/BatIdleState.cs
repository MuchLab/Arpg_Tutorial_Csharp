using Godot;
using System;

public partial class BatIdleState : CharacterState
{
    [Export] private BatWanderState wanderState;
    [Export] private float restDuration = 3;
    private Timer restTimer;
    public override void _Ready()
    {
        restTimer = GetNode<Timer>("RestTimer");
        restTimer.Timeout += _on_rest_timer_timeout;
    }
    public override void OnEnter()
    {
        ((AnimationNodeStateMachinePlayback)animationTree.Get(PARAMETER_PLAYBACK)).Travel("fly");
        character.Velocity = Vector2.Zero;
        restTimer.Start(restDuration);
    }
    public void _on_rest_timer_timeout()
    {
        nextState = wanderState;
    }
}
