using UnityEngine;

public class PlayerCharacterController : Controller
{
    private Character _character;

    public PlayerCharacterController(Character character)
    {
        _character = character;
    }

    public override void SetTarget(Vector3 targetToSet)
    {
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _character.SetMoveDirection(inputDirection);
        _character.SetRotationDirection(inputDirection);
    }
}
