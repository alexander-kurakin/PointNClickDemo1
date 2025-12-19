using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private NavMeshCharacter _character;

    private Controller _playerController;

    private void Awake()
    {
        _playerController = new CompositeController(
            new PlayerNavMeshMovableController(_character), 
            new PlayerMousePointRotatableController(_character,_character));

        _playerController.Enable();
    }

    private void Update()
    {
        _playerController.Update(Time.deltaTime);
    }

}
