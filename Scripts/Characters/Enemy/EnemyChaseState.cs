using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyState
{
    [Export] public Timer chaseTimeNode;
    private CharacterBody3D target;

    protected override void EnterState()
    {
       characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
       chaseTimeNode.Timeout += HandleTimeout;
	   GD.Print("chase state");
       	characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaEntered;
		characterNode.AttackAreaNode.BodyEntered += HandleAttackAreaEntered;
    }

    protected override void ExitState()
    {
        chaseTimeNode.Timeout -= HandleTimeout;
        characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaEntered;
		characterNode.AttackAreaNode.BodyEntered -= HandleAttackAreaEntered;
    }

    private void HandleAttackAreaEntered(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyAttackState>();
    }

    private void HandleTimeout()
    {
        var targets = characterNode.ChaseAreaNode.GetOverlappingBodies();
        if(targets != null && targets.Count > 0)
        {
            target = targets.First() as CharacterBody3D;
            destination = target.GlobalPosition;
        }
        else
        {
            characterNode.StateMachineNode.SwitchState<EenmyReturnState>();
        }
    }


    public override void _PhysicsProcess(double delta)
    {
        Move();
    }
}
