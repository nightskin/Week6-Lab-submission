using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState { get; private set; }
    protected Dictionary<string, State> States;
    private bool running;

    private void Awake()
    {
        States = new Dictionary<string, State>();
    }

    public void Initialize(string startingState)
    {
        if(States.ContainsKey(startingState))
        {
            ChangeState(startingState);
        }
        else if(States.ContainsKey("Idle"))
        {
            ChangeState("Idle");
        }
    }

    public void AddState(string name, State state)
    {
        if (!States.ContainsKey(name))
        {
            States.Add(name, state);
        }
        else
        {
            return;
        }
    }

    public void RemoveState(string name)
    {
        if (!States.ContainsKey(name))
        {
            return;
        }
        else
        {
            States.Remove(name);
        }
    }

    public void ChangeState(string name)
    {
        if(running)
        {
            StopRunningState();
        }
        if (!States.ContainsKey(name)) return;
        currentState = States[name];
        currentState.Start();

        if(currentState.updateInterval > 0)
        {
            InvokeRepeating(nameof(IntervalUpdate), time: 0.0f, currentState.updateInterval);
        }
        running = true;
    }

    private void StopRunningState()
    {
        running = false;
        currentState.Exit();
        CancelInvoke(nameof(IntervalUpdate));
    }

    private void IntervalUpdate()
    {
        if(running)
        {
            currentState.IntervalUpdate();
        }
    }

    private void Update()
    {
        if (running)
        {
            currentState.Update();
        }
    }

    private void FixedUpdate()
    {
        if (running)
        {
            currentState.FixedUpdate();
        }
    }

}

