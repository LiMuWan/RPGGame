using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{
	protected override void EnterState()
	{
		base.EnterState();
		characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);
		characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaEntered;
	}

    protected override void ExitState()
    {
       characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
       characterNode.StateMachineNode.SwitchState<EenmyReturnState>();
    }
}
