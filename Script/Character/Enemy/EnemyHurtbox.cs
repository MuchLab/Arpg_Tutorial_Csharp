using Godot;
using System;

public partial class EnemyHurtbox : Hurtbox
{
    [Export] private Bat bat;
    public override void Hurt(CharacterBody2D hittingCharacter, int damage)
    {
        bat.CurrentHealth -= damage;
        if (bat.CurrentHealth > 0)
            EmitSignal(Hurtbox.SignalName.KnockingbackCharacter, this, hittingCharacter);
        else
            SetDeferred("Monitorable", false);
        GD.Print(bat.CurrentHealth);
    }
}
