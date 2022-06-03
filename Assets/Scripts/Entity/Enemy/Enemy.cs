using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    [SerializeField] private float _damage;

    [HideInInspector] public Agent agent;
    [HideInInspector] public bool isTarget;
    [HideInInspector] public Transform target;

    private EnemyAttack _attack = new EnemyAttack();

    private void Start()
    {
        agent = new Agent(GetComponent<NavMeshAgent>());
        _animator = GetComponent<Animator>();

        _attack.objectTransform = transform;
        _attack.damage = _damage;
    }

    private void FixedUpdate()
    {
        SetAnimation(agent.moveDirection);
        _attack.Attacking();
    }

    private void Update()
    {
        if (isTarget && target != null)
            agent.FollowTarget(target);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GetDamageTrigger"))
            _attack.attacking = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GetDamageTrigger"))
            _attack.attacking = false;
    }
}
