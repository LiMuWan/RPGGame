using Godot;
using System;

public partial class EnemyState : CharacterState
{
    protected Vector3 destination;

    public override void _Ready()
    {
        base._Ready();
        var healthStat = characterNode.GetStatResource(Stat.Health).OnZero += HandleZeroHealth;
    }

    private void HandleZeroHealth()
    {
        characterNode.StateMachineNode.SwitchState<EnemyDeathState>();
    }


    protected Vector3 GetGlobalPosition(int index)
    {
        Vector3 localPosition = characterNode.PathNode.Curve.GetPointPosition(index);
        Vector3 globalPosition = characterNode.GlobalPosition;
        return localPosition + globalPosition;
    }

    protected void Move()
    {
        //手动更新获取下一个寻路点
        characterNode.NavigationNode.GetNextPathPosition();
        characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);
        characterNode.MoveAndSlide();
        characterNode.Flip();//反转
    }

    protected void HandleChaseAreaEntered(Node3D node)
    {
        characterNode.StateMachineNode.SwitchState<EnemyChaseState>();
    }
}
