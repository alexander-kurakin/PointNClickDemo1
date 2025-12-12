using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : Controller
{
    private NavMeshCharacter _character;
    private NavMeshPath _pathToTarget = new NavMeshPath();
    private Vector3 _target;

    public NavMeshController(NavMeshCharacter character)
    {
        _character = character;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _character.SetRotationDirection(_character.CurrentVelocity);

        if (_target != Vector3.zero && _character.IsDead() == false)
        {
            if (_character.TryGetPath(_target, _pathToTarget))
            {
                _character.ResumeMove();
                _character.SetDestination(_target);
                _character.DrawMarker(_target);

                return;
            }
        }

        _character.StopMove();
    }

    public void SetTarget(Vector3 target) => _target = target;
}
