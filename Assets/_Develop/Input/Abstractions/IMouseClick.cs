using UnityEngine;

public interface IMouseClickInput
{
    bool MouseClickButtonPressed { get; }

    Vector3 MousePositon { get; }
}
