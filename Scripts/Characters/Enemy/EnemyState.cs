using Godot;
using System;

public partial class EnemyState : CharacterState
{
	protected Vector3 destination;
	protected Vector3 GetGlobalPosition(int index)
    {
        Vector3 localPosition = characterNode.PathNode.Curve.GetPointPosition(index);
        Vector3 globalPosition = characterNode.GlobalPosition;
        return localPosition + globalPosition;
    }

	protected void Move()
    {
		//注意获取下一个寻路点
		characterNode.NavigationNode.GetNextPathPosition();
        characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);
        characterNode.MoveAndSlide();
    }
}
