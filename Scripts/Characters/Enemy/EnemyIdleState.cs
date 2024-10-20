using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{
	protected override void EnterState()
	{
		base.EnterState();
		characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);
	}

    public override void _PhysicsProcess(double delta)
    {
       characterNode.StateMachineNode.SwitchState<EenmyReturnState>();
    }
}
