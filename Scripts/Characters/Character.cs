using Godot;
using System;
using System.Linq;

public partial class Character : CharacterBody3D
{

    [Export]public StatResource[] Stat{get;private set;}
	[ExportGroup("RequiredNode")]
	[Export]public AnimationPlayer AnimationPlayerNode{get;private set;}
	[Export]public Sprite3D SpriteNode{get;private set;}
    [Export]public StateMachine StateMachineNode{get;private set;}

    [ExportGroup("AI Nodes")]
	[Export] public Path3D PathNode{get;set;}
    [Export] public NavigationAgent3D NavigationNode{get;set;}
    [Export] public Area3D ChaseAreaNode{get;set;}
    [Export] public Area3D AttackAreaNode{get;set;}
    [Export] public Area3D HitAreaNode{get;set;}
    [Export] public Area3D HurtAreaNode{get;set;}
    [Export] public CollisionShape3D hitBoxShapeNode;

    public override void _Ready()
    {
        HurtAreaNode.AreaEntered += HandleHurtAreaEntered;
    }

    private void HandleHurtAreaEntered(Area3D area)
    {
        StatResource health = GetStatResource(global::Stat.Health);
        var player = area.GetOwner<Character>();
        health.StatValue -= player.GetStatResource(global::Stat.Strength).StatValue;
        GD.Print($"{Name}-by-{area.GetOwner<Character>().Name}-attacked , {Name}-health = {health.StatValue}");
    }


    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;
        if(isNotMovingHorizontally){return;}
        bool isMoveLeft = Velocity.X < 0;
        SpriteNode.FlipH = isMoveLeft;
    }

    public void ToggleHitBox(bool flag)
    {
        hitBoxShapeNode.Disabled = flag;
    }

    public StatResource GetStatResource(Stat stat)
    {
        return Stat.Where((element)=>element.StatType == stat).FirstOrDefault();
    }
}
