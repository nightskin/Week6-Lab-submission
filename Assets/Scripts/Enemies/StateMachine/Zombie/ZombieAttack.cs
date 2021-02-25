using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : ZombieStates
{
    private GameObject target;
    private float atkRange = 1;
    private static readonly int MovementZ = Animator.StringToHash("MovementZ");
    private static readonly int Atk = Animator.StringToHash("Atk");

    public ZombieAttack(GameObject followTarget, ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        target = followTarget;
        updateInterval = 5;
    }

    public override void Start()
    {
        owner.navMesh.isStopped = true;
        owner.navMesh.ResetPath();
        owner.anim.SetFloat(MovementZ, 0);
        owner.anim.SetBool(Atk, true);

    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
        //to do
    }

    public override void Update()
    {
        owner.transform.LookAt(target.transform.position,Vector3.up);

        float distanceBetween = Vector3.Distance(owner.transform.position, target.transform.position);
        if(distanceBetween > atkRange)
        {
            StateMachine.ChangeState(ZombieStateType.Follow.ToString());
        }
        // to do zombie health < 1 die
    }

    public override void Exit()
    {
        base.Exit();
        owner.anim.SetBool(Atk, false);
    }

}
