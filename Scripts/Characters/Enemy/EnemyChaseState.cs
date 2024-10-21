using Godot;
using System;

public partial class EnemyChaseState : EnemyState
{
    protected override void EnterState()
    {
       characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
	   GD.Print("chase state");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
