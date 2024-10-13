using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
	[Export] private Timer dashTimerNode;
	[Export(PropertyHint.Range,"0,20,0.1")] private float speed = 10;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		dashTimerNode.Timeout += HandlerDashTimeout;
	}

	private void HandlerDashTimeout()
	{
		characterNode.Velocity *= Vector3.Zero;
		characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		characterNode.MoveAndSlide();
		characterNode.Flip();
	}

	protected override void EnterState()
	{
		base.EnterState();
		characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_DASH);
		characterNode.Velocity = new Vector3(characterNode.direction.X, 0, characterNode.direction.Y);
		if (characterNode.Velocity == Vector3.Zero)
		{
			characterNode.Velocity = characterNode.SpriteNode.FlipH ? Vector3.Left : Vector3.Right;
		}
		characterNode.Velocity *= speed;
		dashTimerNode.Start();
	}
}
