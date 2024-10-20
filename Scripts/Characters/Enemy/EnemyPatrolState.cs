using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{
	private int pointIndex = 0;
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
		pointIndex = 1;
		destination = GetGlobalPosition(pointIndex);
		characterNode.NavigationNode.TargetPosition = destination;
		characterNode.NavigationNode.NavigationFinished += HandlerNavigationFinished;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }

    private void HandlerNavigationFinished()
    {
       pointIndex = Mathf.Wrap(pointIndex+1,0,characterNode.PathNode.Curve.PointCount);
	   destination = GetGlobalPosition(pointIndex);
	   characterNode.NavigationNode.TargetPosition = destination;
    }

}
