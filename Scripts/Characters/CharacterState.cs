using Godot;
using System;

public partial class CharacterState : Node
{
	protected Character characterNode;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		characterNode = GetOwner<Character>();
		SetPhysicsProcess(false);
		SetProcessInput(false);
	}

	public override void _Notification(int what)
	{
		if (what == GameConstants.NOTIFACATION_ENTER_STATE)
		{
			EnterState();
			SetPhysicsProcess(true);
			SetProcessInput(true);
		}
		else if (what == GameConstants.NOTIFACATION_EXIT_STATE)
		{
			SetPhysicsProcess(false);
			SetProcessInput(false);
			ExitState();
		}
	}

	protected virtual void EnterState(){}
	protected virtual void ExitState(){}
}
