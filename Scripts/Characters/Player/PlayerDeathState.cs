using Godot;
using System;

public partial class PlayerDeathState : PlayerState
{
	 protected override void EnterState()
    {
       characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_DEATH);
	   characterNode.AnimationPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
       characterNode.QueueFree();
    }

    protected override void ExitState()
    {
         characterNode.AnimationPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }
}
