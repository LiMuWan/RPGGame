using Godot;
using System;

public partial class StateMachine : Node
{
	[Export]
	public Node currentState;
	[Export]
	public Node[] states;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		currentState.Notification(GameConstants.NOTIFACATION_ENTER_STATE);
	}	

    public void SwitchState<T>()
	{
		Node newState = null;
		foreach(Node state in states)
		{
			if(state is T)
			{
				newState = state;
			}
		}

		if(newState == null){return;}

		currentState.Notification(GameConstants.NOTIFACATION_EXIT_STATE);
		currentState = newState;
		currentState.Notification(GameConstants.NOTIFACATION_ENTER_STATE);
	}
}
