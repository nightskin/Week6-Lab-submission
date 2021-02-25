using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(StateMachine))]
public class ZombieComponent : MonoBehaviour
{
    public NavMeshAgent navMesh { get; private set; }
    public StateMachine StateMachine { get; private set; }
    public Animator anim { get; private set; }
    public GameObject target;
    

    [SerializeField] private bool _Debug;

    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        StateMachine = GetComponent<StateMachine>();
    }

    void Start()
    {
        if (_Debug)
        {
            Initialize(target);
        }
    }
    
    public void Initialize(GameObject followTarget)
    {
        target = followTarget;
        ZombieIdle idle = new ZombieIdle(this, StateMachine);
        StateMachine.AddState(ZombieStateType.Idle.ToString(), idle);

        ZombieFollow follow = new ZombieFollow(target,this, StateMachine);
        StateMachine.AddState(ZombieStateType.Follow.ToString(), follow);

        ZombieAttack attack = new ZombieAttack(target, this, StateMachine);
        StateMachine.AddState(ZombieStateType.Attack.ToString(), attack);

        ZombieDeath dead = new ZombieDeath(this, StateMachine);
        StateMachine.AddState(ZombieStateType.Dead.ToString(),dead);

        StateMachine.Initialize(ZombieStateType.Dead.ToString());
    }


}
