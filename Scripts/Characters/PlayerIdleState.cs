using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		GD.Print("Player Idle _PhysicsProcess ");
		if(characterNode.direction != Vector2.Zero)
		{
			characterNode.StateMachineNode.SwitchState<PlayerMoveState>();
		}
	}

    protected override void EnterState()
    {
        base.EnterState();
		characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);
    }
}
