using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{
	[Export(PropertyHint.Range, "0,20,0.1")] private float speed = 5;
	public override void _PhysicsProcess(double delta)
	{
		// GD.Print("Player Move _PhysicsProcess ");
		if ((characterNode as Player).direction == Vector2.Zero)
		{
			characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
			return;
		}

		// GD.Print("Player physic process !");
		characterNode.Velocity = new Vector3((characterNode as Player).direction.X, 0, (characterNode as Player).direction.Y);
		characterNode.Velocity *= speed;
		characterNode.MoveAndSlide();
		characterNode.Flip();
	}

	public override void _Input(InputEvent @event)
	{
		CheckForAttackInput();
		if (Input.IsActionJustPressed(GameConstants.INPUT_DASH_BACKWARD))
		{
			characterNode.StateMachineNode.SwitchState<PlayerDashState>();
		}
	}

	protected override void EnterState()
	{
		base.EnterState();
		characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
	}
}
