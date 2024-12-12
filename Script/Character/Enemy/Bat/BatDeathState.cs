using Godot;
using System;

public partial class BatDeathState : CharacterState
{
    public override void OnEnter()
    {
        character.QueueFree();
    }
    public void _on_bat_bat_death()
    {
        EmitSignal(CharacterState.SignalName.InterruptState, this);
    }
}
