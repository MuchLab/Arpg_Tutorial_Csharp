using Godot;
using System;

public partial class StateDebugLabel : Label
{
    [Export] private CharacterStateMachine stateMachine;

    public override void _Process(double delta)
    {
        Text = $"State:{stateMachine.currentState.Name}";
    }
}
