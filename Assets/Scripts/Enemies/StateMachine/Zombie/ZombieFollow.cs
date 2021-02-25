using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollow : ZombieStates
{
    private readonly GameObject target;
    private const float StopDistance = 3f;
    private static readonly int MovementZ = Animator.StringToHash("MovementZ");

    public ZombieFollow(GameObject followTarget, ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        target = followTarget;
        updateInterval = 2;

    }

    public override void Start()
    {
        base.Start();
        owner.navMesh.destination = target.transform.position;
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
        owner.navMesh.destination = target.transform.position;
    }

    public override void Update()
    {
        base.Update();
        owner.anim.SetFloat(MovementZ,owner.navMesh.velocity.normalized.z);
        
        if(Vector3.Distance(owner.transform.position,target.transform.position) < StopDistance)
        {
            //StateMachine.ChangeState(ZombieStateType.Attack.ToString());
            Debug.Log("Attacking");
        }
    }
}
