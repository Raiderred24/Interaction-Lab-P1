using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GamePlayState : State
{
    private GameFSM _statemachine;
    private GameController _controller;

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _statemachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("STATE: Game Play");
        Debug.Log("Listen For Player Inputs");
        Debug.Log("Display Player HUD");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        Debug.Log("Checking for Win Condition");
        Debug.Log("Checking for Lose Condition");
    }
}
