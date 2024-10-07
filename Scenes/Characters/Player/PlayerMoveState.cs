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
		}
    }

    public override void _Notification(int what)
    {
		if(what == 5001)
		{
			characterNode.animationPlayerNode.Play(GameConstants.ANIM_MOVE);
			SetPhysicsProcess(true);
		}
		else if(what == 5002)
		{
			SetPhysicsProcess(false);
		}
    }
}
