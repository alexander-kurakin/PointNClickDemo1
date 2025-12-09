using UnityEngine;
using UnityEngine.AI;

public class AgentCharacterController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private NavMeshAgent _agent;
    private DirectionalRotator _rotator;
    private Vector3 _target;

    private void Awake()
    {
        _target = transform.position;
        _agent = GetComponent<NavMeshAgent>();

        _rotator = new DirectionalRotator(transform, _rotationSpeed);
    }

    private void Update()
    {
        _agent.SetDestination(_target);
        _agent.updateRotation = false;

        _rotator.SetInputDirection(_agent.desiredVelocity);
        _rotator.Update(Time.deltaTime);
    }

    public void SetTarget(Vector3 target) => _target = target;

}
