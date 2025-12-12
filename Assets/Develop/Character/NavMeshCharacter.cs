using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NavMeshCharacter : MonoBehaviour, IDamageable
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _rotationSpeed = 900;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _injuryThreshold = 30;

    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshCharacterView _view;

    private int _currentHealth;
    private bool _isDead = false;

    private NavMeshAgent _agent;
    private NavMeshAgentMover _mover;
    private DirectionalRotator _rotator;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _mover = new NavMeshAgentMover(_agent, _moveSpeed);
        _rotator = new DirectionalRotator(transform, _rotationSpeed);

        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        _rotator.Update(Time.deltaTime);
    }

    public void SetDestination (Vector3 position) => _mover.SetDestination(position);
    public void StopMove() => _mover.Stop();
    public void ResumeMove() => _mover.Resume();
    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);
    public bool TryGetPath (Vector3 targetPosition, NavMeshPath pathToTarget)
        => NavMeshUtils.TryGetPath(_agent, targetPosition, pathToTarget);

    public void DrawMarker(Vector3 position)
    { 
        _view.DrawMarkerOnGround(position);
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Debug.LogError(damage);
            return;
        }

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _view.AnimateDeath();
            _isDead = true;
            return;
        }

        _view.AnimateHit();
    }

    public int GetCurrentHealth() => _currentHealth;
    public bool IsDead() => _isDead;
    public bool IsInjured() => _currentHealth <= _injuryThreshold;
}
