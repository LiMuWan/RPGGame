using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("RequiredNode")]
	[Export]public AnimationPlayer animationPlayerNode;
	[Export]public Sprite3D spriteNode;
    [Export]public StateMachine stateMachineNode;
	public Vector2 direction = new();

    public override void _PhysicsProcess(double delta)
    {
        // GD.Print("Player physic process !");
		Velocity = new Vector3(direction.X,0,direction.Y);
		Velocity *= 5;
		MoveAndSlide();
        Flip();
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT, GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_BACKWARD);
    }

    private void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;
        if(isNotMovingHorizontally){return;}
        bool isMoveLeft = Velocity.X < 0;
        spriteNode.FlipH = isMoveLeft;
    }
}
