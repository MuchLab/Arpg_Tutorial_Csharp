using Godot;
using System;

public abstract partial class Hurtbox : Area2D
{
    [Signal] public delegate void KnockingbackCharacterEventHandler(Hurtbox hurtbox, CharacterBody2D hittingCharacter);

    public abstract void Hurt(CharacterBody2D hittingCharacter, int damage);
}
