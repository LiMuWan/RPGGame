using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("RequiredNode")]
	[Export]public AnimationPlayer AnimationPlayerNode{get;private set;}
	[Export]public Sprite3D SpriteNode{get;private set;}
    [Export]public StateMachine StateMachineNode{get;private set;}
	public Vector2 direction = new();

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT, GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_BACKWARD);
    }

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;
        if(isNotMovingHorizontally){return;}
        bool isMoveLeft = Velocity.X < 0;
        SpriteNode.FlipH = isMoveLeft;
    }
}
