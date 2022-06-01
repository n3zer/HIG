using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    [SerializeField] private float _damage;

    [HideInInspector] public Agent agent;
    [HideInInspector] public bool isTarget;
    [HideInInspector] public Transform target;




    private void Start()
    {
        agent = new Agent(GetComponent<NavMeshAgent>());
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SetAnimation(agent.moveDirection);
    }

    private void Update()
    {
        if (isTarget)
            agent.FollowTarget(target);
        
        
    }
}
