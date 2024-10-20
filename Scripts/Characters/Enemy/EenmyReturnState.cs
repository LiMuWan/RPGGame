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
		//代理先于服务器同步，然后再检查代理是否到达了目标位置，如果到达会更新到下一个目标位置
        if (characterNode.NavigationNode.IsNavigationFinished())
        {
            GD.Print("Reach the destination");
			characterNode.StateMachineNode.SwitchState<EnemyPatrolState>();
			return;
        }

        Move();
    }
}
