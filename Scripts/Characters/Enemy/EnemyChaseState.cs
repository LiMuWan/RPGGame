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
    }

    protected override void ExitState()
    {
        chaseTimeNode.Timeout -= HandleTimeout;
    }

    private void HandleTimeout()
    {
        target = characterNode.ChaseAreaNode.GetOverlappingBodies().First() as CharacterBody3D;
        destination = target.GlobalPosition;
    }


    public override void _PhysicsProcess(double delta)
    {
        Move();
    }
}
