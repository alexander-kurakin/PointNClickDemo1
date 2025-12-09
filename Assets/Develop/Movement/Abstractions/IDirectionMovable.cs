using UnityEngine;

public interface IDirectionMovable : ITransformPosition
{
    Vector3 CurrentVelocity { get; }
    void SetMoveDirection(Vector3 inputDirection);
}
