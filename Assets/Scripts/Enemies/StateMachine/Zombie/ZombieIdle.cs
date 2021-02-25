using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdle : ZombieStates
{
    private static readonly int MovementZ = Animator.StringToHash("MovementZ");
    public ZombieIdle(ZombieComponent zombie, StateMachine stateMachine) : base(zombie,stateMachine)
    {

    }

    public override void Start()
    {
        base.Start();
        owner.navMesh.isStopped = true;
        owner.navMesh.ResetPath();
        owner.anim.SetFloat(MovementZ, 0);
    }
}
