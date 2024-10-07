using Godot;
using System;

public partial class PlayerDashState : Node
{
	private Player characterNode;
	[Export] private Timer dashTimerNode;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		characterNode = GetOwner<Player>();
		dashTimerNode.Timeout += HandlerDashTimeout;
	}

    private void HandlerDashTimeout()
    {
       characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
    }


    public override void _Notification(int what)
    {
        base._Notification(what);
		if(what == 5001)
		{
			characterNode.animationPlayerNode.Play(GameConstants.ANIM_DASH);
			dashTimerNode.Start();
		}
    }
}
