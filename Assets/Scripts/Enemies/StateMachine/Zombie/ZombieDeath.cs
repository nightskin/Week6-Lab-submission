using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : ZombieStates
{
    private static readonly int MovementZ = Animator.StringToHash("MovementZ");
    private static readonly int Dead = Animator.StringToHash("Dead");

    public ZombieDeath(ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {

    }

    public override void Start()
    {
        base.Start();
        owner.navMesh.isStopped = true;
        owner.navMesh.ResetPath();
        owner.anim.SetFloat(MovementZ, 0);
        owner.anim.SetBool(Dead, true);
    }

    public override void Exit()
    {
        base.Exit();
        owner.navMesh.isStopped = false;
        owner.anim.SetBool(Dead, false);
    }

}
