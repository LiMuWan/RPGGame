using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		// GD.Print("Player Idle _PhysicsProcess ");
		if((characterNode as Player).direction != Vector2.Zero)
		{
			characterNode.StateMachineNode.SwitchState<PlayerMoveState>();
		}
	}

    protected override void EnterState()
    {
        base.EnterState();
		characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);
    }

	public override void _Input(InputEvent @event)
	{
		CheckForAttackInput();
		if (Input.IsActionJustPressed(GameConstants.INPUT_DASH_BACKWARD))
		{
			characterNode.StateMachineNode.SwitchState<PlayerDashState>();
		}
	}
}
