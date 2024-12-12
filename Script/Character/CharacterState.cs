using Godot;

public partial class CharacterState : Node
{
    [Signal] public delegate void InterruptStateEventHandler(CharacterState state);

    [Export] public bool canMove = true;
    [Export] public bool shouldFacing = false;
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
