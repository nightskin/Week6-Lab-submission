using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStates : State
{
    protected ZombieComponent owner;

    public ZombieStates(ZombieComponent zombie, StateMachine stateMachine): base(stateMachine)
    {
        owner = zombie;
    }
}

public enum ZombieStateType
{
    Idle,
    Attack,
    Follow,
    Dead
}