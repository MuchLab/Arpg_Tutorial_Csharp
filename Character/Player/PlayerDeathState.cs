using Godot;
using System;

public partial class PlayerDeathState : CharacterState
{
    public override void OnEnter()
    {
        ((AnimationNodeStateMachinePlayback)animationTree.Get(PARAMETER_PLAYBACK)).Travel("death");
    }
    public void _on_player_player_death()
    {
        EmitSignal(CharacterState.SignalName.InterruptState, this);
    }
}
