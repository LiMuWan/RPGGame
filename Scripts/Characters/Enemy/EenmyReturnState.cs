using Godot;
using System;

public partial class EenmyReturnState : EnemyState
{
    public override void _Ready()
    {
        base._Ready();
        destination = GetGlobalPosition(0);
    }

    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
		characterNode.NavigationNode.TargetPosition = destination;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.NavigationNode.IsNavigationFinished())
        {
            GD.Print("Reach the destination");
			characterNode.StateMachineNode.SwitchState<EnemyPatrolState>();
			return;
        }

        Move();
    }
}
