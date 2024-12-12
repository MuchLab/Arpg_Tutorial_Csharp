using Godot;
using System;

public partial class PlayerAttackState : CharacterState
{
    [Export] private PlayerIdleState idleState;
    public override void OnEnter()
    {
        ((AnimationNodeStateMachinePlayback)animationTree.Get(PARAMETER_PLAYBACK)).Travel("attack");
    }
    public override void StateProcess(double delta)
    {
        animationTree.Set("parameters/attack/blend_position", defaultDirection);
    }
    public void _on_animation_tree_animation_finished(string animationName)
    {
        if (animationName.Contains("attack"))
            nextState = idleState;
    }
}
