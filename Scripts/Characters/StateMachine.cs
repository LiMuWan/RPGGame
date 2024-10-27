using Godot;
using System;
using System.Linq;

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
		Node newState = states.Where((element)=>element is T).FirstOrDefault();
		if(newState == null){return;}

		currentState.Notification(GameConstants.NOTIFACATION_EXIT_STATE);
		currentState = newState;
		currentState.Notification(GameConstants.NOTIFACATION_ENTER_STATE);
	}
}
