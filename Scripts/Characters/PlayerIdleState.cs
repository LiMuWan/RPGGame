using Godot;
using System;

public partial class PlayerIdleState : Node
{
	private Player characterNode;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		characterNode = GetOwner<Player>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		GD.Print("Player Idle _PhysicsProcess ");
		if(characterNode.direction != Vector2.Zero)
		{
			characterNode.stateMachineNode.SwitchState<PlayerMoveState>();
		}
	}

    public override void _Notification(int what)
    {
		if(what == 5001)
		{
			characterNode.animationPlayerNode.Play(GameConstants.ANIM_IDLE);
			SetPhysicsProcess(true);
		}
		else if(what == 5002)
		{
           SetPhysicsProcess(false);
		}
    }
}
