using UnityEngine;
using UnityEngine.AI;

public class PlayerPointClickController : Controller
{
    private Vector3 _currentTarget;
    private NavMeshAgent _agent;
    
    public PlayerPointClickController(NavMeshAgent agent)
    {
        _agent = agent;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _agent.SetDestination(_currentTarget * deltaTime);
    }

    public override void SetTarget(Vector3 targetToSet)
    { 
        _currentTarget = targetToSet;
    }

    public Vector3 GetCurrentTarget() 
    { 
        return _currentTarget;
    }
}
