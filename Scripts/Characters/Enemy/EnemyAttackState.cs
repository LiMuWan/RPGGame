using Godot;
using System;

public partial class EnemyAttackState : EnemyState
{
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK);
    }
}
