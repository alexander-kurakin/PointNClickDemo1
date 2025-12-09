using System;
using UnityEngine;
using UnityEngine.AI;

public class CharacterView : MonoBehaviour
{
    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");

    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;

    private void Update()
    {
        if (_agent.velocity.magnitude> 0.05f)
            StartRunning();
        else
            StopRunning();
    }

    private void StopRunning()
    {
        _animator.SetBool(IsRunningKey, false);
    }

    private void StartRunning()
    {
        _animator.SetBool(IsRunningKey, true);
    }
}
