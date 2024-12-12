using Godot;
using System;

public partial class SoftCollision : Area2D
{
    public Vector2 GetPushDirection()
    {
        var areas = GetOverlappingAreas();
        var pushDirection = Vector2.Zero;
        if(areas.Count > 0)
        {
            var area = areas[0];
            pushDirection = area.GlobalPosition.DirectionTo(GlobalPosition);
        }
        return pushDirection;
    }
}
