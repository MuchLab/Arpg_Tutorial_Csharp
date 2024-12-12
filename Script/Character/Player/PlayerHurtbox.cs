using Godot;
using System;

public partial class PlayerHurtbox : Hurtbox
{
    [Export] private Player player;
    public override void Hurt(CharacterBody2D hittingCharacter, int damage)
    {
        player.CurrentHealth -= damage;
        if (player.CurrentHealth <= 0)
            SetDeferred("Monitorable", false);
        else
            EmitSignal(Hurtbox.SignalName.KnockingbackCharacter, this, hittingCharacter);
    }
}
