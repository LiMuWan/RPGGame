using Godot;
using System;

public partial class EenmyReturnState : EnemyState
{

    private Vector3 destination;

    public override void _Ready()
    {
        base._Ready();
		destination = characterNode.PathNode.Curve.GetPointPosition(0);
    }
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
		characterNode.GlobalPosition = destination + characterNode.Position;
    }
}
