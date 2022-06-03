using System;
using UnityEngine;
using UnityEngine.AI;

public class Agent
{
    private Vector2 _target;
    private NavMeshAgent _agent;

    public Vector2 moveDirection
    {
        get 
        { 
            return Simplify(_agent.velocity); 
        }
    }

    public Agent(NavMeshAgent agent)
    {
        _agent = agent;
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;
    }

    public void FollowTarget(Transform target)
    {
        Vector2 point = target.position;
        _target = point;
        _agent.SetDestination(_target);
    }


    private Vector2 Simplify(Vector2 point)
    {
        if (Math.Abs(point.x) > Math.Abs(point.y))
        {
            point.x = point.x / Math.Abs(point.x);
            point.y = 0;
            return point;
        }
        else if (Math.Abs(point.x) < Math.Abs(point.y))
        {
            point.y = point.y / Math.Abs(point.y);
            point.x = 0;
            return point;
        }
        return new Vector2(0, 0);
    }



}
