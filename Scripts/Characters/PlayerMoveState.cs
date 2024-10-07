using Godot;
using System;

public partial class PlayerMoveState : Node
{
	private Player characterNode;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		characterNode = GetOwner<Player>();
	}

    public override void _PhysicsProcess(double delta)
    {
		GD.Print("Player Move _PhysicsProcess ");
		if(characterNode.direction == Vector2.Zero)
		{
			characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
		    return;
		}

		   // GD.Print("Player physic process !");
		characterNode.Velocity = new Vector3(characterNode.direction.X,0,characterNode.direction.Y);
		characterNode.Velocity *= 5;
		characterNode.MoveAndSlide();
        characterNode.Flip();
    }

    public override void _Notification(int what)
    {
		if(what == 5001)
		{
			characterNode.animationPlayerNode.Play(GameConstants.ANIM_MOVE);
			SetPhysicsProcess(true);
			SetProcessInput(true);
		}
		else if(what == 5002)
		{
			SetPhysicsProcess(false);
			SetProcessInput(false);
		}
    }

	public override void _Input(InputEvent @event)
    {
       if(Input.IsActionJustPressed(GameConstants.INPUT_DASH_BACKWARD))
	   {
			characterNode.stateMachineNode.SwitchState<PlayerDashState>();
	   }
    }
}
