using Godot;
using System;

public partial class BatChaseState : CharacterState
{
    [Export] private float maxSpeed = 75;
    [Export] private float acceleration = 25;
    [Export] private BatResumeState resumeState;
    [Export] private SoftCollision softCollision;

    private Player player = null;
    public override void OnEnter()
    {
        ((AnimationNodeStateMachinePlayback)animationTree.Get(PARAMETER_PLAYBACK)).Travel("fly");
    }
    public override void StateProcess(double delta)
    {
        if(player != null)
        {
            var direction = character.GlobalPosition.DirectionTo(player.GlobalPosition);
            character.Velocity = character.Velocity.MoveToward(direction * maxSpeed, acceleration);
            if(softCollision != null && softCollision.GetOverlappingAreas().Count >0)
            {
                var pushDirection = softCollision.GetPushDirection();
                character.Velocity = character.Velocity.MoveToward(pushDirection * maxSpeed, acceleration);
            }
        }
    }
    public void _on_player_detector_body_entered(Node2D body)
    {
        if (body is Player _player)
        {
            player = _player;
            EmitSignal(CharacterState.SignalName.InterruptState, this);
        }
    }
    public void _on_player_detector_body_exited(Node2D body)
    {
        if (body is Player)
        {
            player = null;
            EmitSignal(CharacterState.SignalName.InterruptState, resumeState);
        }
    }
}
