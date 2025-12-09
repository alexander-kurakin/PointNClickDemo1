using UnityEngine;

public interface IDirectionRotatable : ITransformPosition
{
    Quaternion CurrentRotation { get; }
    void SetRotationDirection(Vector3 inputDirection);
}
