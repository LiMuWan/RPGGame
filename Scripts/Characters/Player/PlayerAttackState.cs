using Godot;
using System;

public partial class PlayerAttackState : PlayerState
{
	//退出的时候重置连击
	[Export] public Timer comboTimer;
	private int comboCounter = 1;
	private int maxComboCounter = 2;

    public override void _Ready()
    {
        base._Ready();
		comboTimer.Timeout += ()=> comboCounter = 1;
    }
    protected override void EnterState()
	{
		characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK + comboCounter,-1,1.5f);
		characterNode.AnimationPlayerNode.AnimationFinished += OnAnimationFinished;
	}

	protected override void ExitState()
	{
		characterNode.AnimationPlayerNode.AnimationFinished -= OnAnimationFinished;
		comboTimer.Start();
	}

	private void OnAnimationFinished(StringName animName)
	{
		comboCounter++;
		comboCounter = Mathf.Wrap(comboCounter, 1, maxComboCounter + 1);
		characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
		characterNode.ToggleHitBox(true);
	}

    private void PerformHit()
	{
		Vector3 newPosition = characterNode.SpriteNode.FlipH ? Vector3.Left:Vector3.Right;
		float distanceMultiplier = 0.75f;
		newPosition *= distanceMultiplier;
		characterNode.HitAreaNode.Position = newPosition;
		characterNode.ToggleHitBox(false);
	}

}
