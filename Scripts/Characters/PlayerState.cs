using Godot;
using System;

public partial class PlayerState : Node
{
	protected Player characterNode;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		characterNode = GetOwner<Player>();
		SetPhysicsProcess(false);
		SetProcessInput(false);
	}

	public override void _Notification(int what)
	{
		if (what == 5001)
		{
			EnterState();
			SetPhysicsProcess(true);
			SetProcessInput(true);
		}
		else if (what == 5002)
		{
			SetPhysicsProcess(false);
			SetProcessInput(false);
		}
	}

	protected virtual void EnterState(){}
}
