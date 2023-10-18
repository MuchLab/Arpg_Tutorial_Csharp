using Godot;
using System;

public partial class Hitbox : Area2D
{
    [Export] private CharacterBody2D character;
    [Export] private int damage = 10;
    public void _on_area_entered(Area2D area)
    {
        if (area is Hurtbox hurtbox)
        {
            hurtbox.Hurt(character, damage);
        }
    }
}
