using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlongMovableVelocityRotatableController : Controller
{
    private IDirectionRotatable _rotatable;
    private IDirectionMovable _movable;

    public AlongMovableVelocityRotatableController(IDirectionRotatable rotatable, IDirectionMovable movable)
    {
        _rotatable = rotatable;
        _movable = movable;
    }

    public override void SetTarget(Vector3 targetToSet)
    {
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _rotatable.SetRotationDirection(_movable.CurrentVelocity);
    }
}
