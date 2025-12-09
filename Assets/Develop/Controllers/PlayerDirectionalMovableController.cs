using UnityEngine;

public class PlayerDirectionalMovableController : Controller
{
    private IDirectionMovable _movable;

    public PlayerDirectionalMovableController(IDirectionMovable movable)
    {
        _movable = movable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _movable.SetMoveDirection(inputDirection);
    }

    public override void SetTarget(Vector3 targetToSet)
    { }
    
}
