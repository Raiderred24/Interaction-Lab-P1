using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineMB : MonoBehaviour
{
   public State CurrentState { get; private set; }
    private State _previouState;

    private bool _inTransition = false;

    public void ChangeState(State newState)
    {
        // ensure we're ready for a new state
        if (CurrentState == newState || _inTransition)
            return;
        ChangeStateSequence(newState);
    }

    private void ChangeStateSequence(State newState)
    {
        _inTransition = true;
        // run our next sequence BEFORE moving to a new state
        CurrentState?.Exit();
        StoreStateAsPrevious(newState);

        CurrentState = newState;

        // begin our new EnterSequence
        CurrentState?.Enter();
        _inTransition = false;
    }

    private void StoreStateAsPrevious(State newState)
    {
        // if there is no previous state, this is our first
        if (_previouState == null && newState != null)
            _previouState = newState;
        // otherwise, sore our current state as previous
        else if (_previouState != null)
            ChangeState(_previouState);
        else
            Debug.LogWarning("This is no previous state ti change to!");
        // virtual allows us to overdide in our FSM to check fo 'AnyState' types of conditions
    }
        protected virtual void Update()
    {
        // simulate update ticks in states
        if (CurrentState != null && !_inTransition)
            CurrentState.Tick();
    }

    protected virtual void FixedUpdate()
    {
        // simulate FixedUpdate in states
        if (CurrentState != null && !_inTransition)
            CurrentState.FixedTick();
    }

    protected virtual void onDestroy()
    {
        CurrentState?.Exit();
    }

}
