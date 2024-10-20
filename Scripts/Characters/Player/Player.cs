using Godot;
using System;

public partial class Player : Character
{

	public Vector2 direction = new();

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT, GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_BACKWARD);
    }
}