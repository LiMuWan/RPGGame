using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{
	[Export] public Timer idleTimeNode;
	[Export(PropertyHint.Range,"0,20,0.1")] public int maxIdleTime = 4;
	private int pointIndex = 0;
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
		pointIndex = 1;
		destination = GetGlobalPosition(pointIndex);
		characterNode.NavigationNode.TargetPosition = destination;
		characterNode.NavigationNode.NavigationFinished += HandlerNavigationFinished;
		idleTimeNode.Timeout += HandlerTimeout;
    }

	private void HandlerTimeout()
	{
		characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
		pointIndex = Mathf.Wrap(pointIndex + 1, 0, characterNode.PathNode.Curve.PointCount);
		destination = GetGlobalPosition(pointIndex);
		characterNode.NavigationNode.TargetPosition = destination;
	}


	public override void _PhysicsProcess(double delta)
    {
		if(!idleTimeNode.IsStopped())
		{
			return;
		}
        Move();
    }

    private void HandlerNavigationFinished()
    {
	   characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);
	   RandomNumberGenerator randomNumberGenerator = new();
	   idleTimeNode.WaitTime = randomNumberGenerator.RandfRange(0,maxIdleTime);
	   idleTimeNode.Start();
    }

}
