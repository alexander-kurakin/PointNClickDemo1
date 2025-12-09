using UnityEngine;

public class PlayerDirectionalRotatableController : Controller
{
    private IDirectionRotatable _rotatable;

    public PlayerDirectionalRotatableController(IDirectionRotatable rotatable)
    {
        _rotatable = rotatable;
    }

    public override void SetTarget(Vector3 targetToSet)
    {
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _rotatable.SetRotationDirection(inputDirection);
    }
}
