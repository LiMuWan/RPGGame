using Godot;
using System;

public partial class Character : CharacterBody3D
{

	[ExportGroup("RequiredNode")]
	[Export]public AnimationPlayer AnimationPlayerNode{get;private set;}
	[Export]public Sprite3D SpriteNode{get;private set;}
    [Export]public StateMachine StateMachineNode{get;private set;}

    [ExportGroup("AI Nodes")]
	[Export] public Path3D PathNode{get;set;}
    [Export] public NavigationAgent3D NavigationNode{get;set;}
    [Export] public Area3D ChaseAreaNode{get;set;}

	public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;
        if(isNotMovingHorizontally){return;}
        bool isMoveLeft = Velocity.X < 0;
        SpriteNode.FlipH = isMoveLeft;
    }
}
