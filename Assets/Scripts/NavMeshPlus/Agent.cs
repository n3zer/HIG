using UnityEngine;
using UnityEngine.AI;

public class Agent
{
    private Transform _target;
    private NavMeshAgent _agent;

    public Agent(NavMeshAgent agent)
    {
        _agent = agent;

        _agent.updateUpAxis = false;
        _agent.updateRotation = false;
    }

    public void FollowTarget(Transform target)
    {
        _target = target;
        _agent.SetDestination(_target.position);
    }

    [System.Obsolete]
    public void StopFollowTarget()
    {
        _agent.Stop();
    }



}
