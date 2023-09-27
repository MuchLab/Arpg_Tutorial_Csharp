using Godot;
using System;

public partial class CharacterState : Node
{
    [Export] public bool canMove = true;
    protected const string PARAMETER_PLAYBACK = "parameters/playback";
    public CharacterState nextState;
    public CharacterBody2D character;
    public AnimationTree animationTree;
    public static Vector2 defaultDirection = Vector2.Down;

    public virtual void StateProcess(double delta) { }
    public virtual void StateInput(InputEvent @event) { }
    public virtual void OnEnter() { }
    public virtual void OnExit() { }
}
