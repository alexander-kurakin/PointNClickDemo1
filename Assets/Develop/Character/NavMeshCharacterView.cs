using UnityEngine;
using UnityEngine.UI;

public class NavMeshCharacterView : MonoBehaviour
{
    private const string InjuredLayerName = "Injured";
    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private readonly int IsDeadKey = Animator.StringToHash("IsDead");
    private readonly int TakeDamageTriggerKey = Animator.StringToHash("TakeDamage");

    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshCharacter _character;
    [SerializeField] private GameObject _targetMarkerPrefab;
    [SerializeField] private Slider _slider;

    private bool _isInjuredSynchronised = false;
    private GameObject _currentTargetMarker;

    private void Update()
    {
        if (_isInjuredSynchronised == false)
            AnimateInjury();

        ShowHP();

        if (_character.CurrentVelocity.magnitude> 0.05f)
            StartRunning();
        else
            StopRunning();
    }

    private void AnimateInjury()
    {
        if (_character.IsInjured())
        {
            int injuredLayerIndex = _animator.GetLayerIndex(InjuredLayerName);
            _animator.SetLayerWeight(injuredLayerIndex, 1f);

            _isInjuredSynchronised = true;
        }
    }

    private void ShowHP()
    {
        float currentHP = (float) _character.GetCurrentHealth() / 100;
        _slider.value = currentHP;
    }    

    private void StopRunning()
    {
        _animator.SetBool(IsRunningKey, false);
    }

    private void StartRunning()
    {
        _animator.SetBool(IsRunningKey, true);
    }

    public void DrawMarkerOnGround(Vector3 position)
    {
        if (_currentTargetMarker != null)
            Destroy(_currentTargetMarker.gameObject);

        _currentTargetMarker = Instantiate(_targetMarkerPrefab, position, Quaternion.identity);
    }

    public void AnimateDeath()
    {
        _animator.SetBool(IsDeadKey, true);
    }

    public void AnimateHit()
    {
        _animator.SetTrigger(TakeDamageTriggerKey);
    }
}
