using Godot;
using System;
using System.Xml.Serialization;

public partial class Hitbox : Area2D
{
    [Signal] public delegate void HitStopedEventHandler();

    [Export] private CharacterBody2D character;
    [Export] private int damage = 10;

    public void _on_area_entered(Area2D area)
    {
        if (area is Hurtbox hurtbox)
        {
            EmitSignal(SignalName.HitStoped);
            hurtbox.Hurt(character, damage);
        }
    }
}