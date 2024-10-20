using Godot;
using System;

public partial class EenmyReturnState : EnemyState
{

    private Vector3 destination;

    public override void _Ready()
    {
        base._Ready();
		Vector3 localPosition = characterNode.PathNode.Curve.GetPointPosition(0);
		Vector3 globalPosition = characterNode.GlobalPosition;
		destination = localPosition + globalPosition;
    }
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
    }

    public override void _PhysicsProcess(double delta)
    {
       if(characterNode.GlobalPosition == destination)
	   {
		 	GD.Print("Reach the destination");
	   }

	   characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);
	   characterNode.MoveAndSlide();
    }
}
