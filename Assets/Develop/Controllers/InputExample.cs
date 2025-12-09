using UnityEngine;
using UnityEngine.AI;

public class InputExample : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private AgentCharacterController _agentCharacterController;

    private Vector3 _mouseHitPosition = Vector3.zero;

    private void Update()
    {
        Ray mousePointRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mousePointRay, out RaycastHit hitInfo, 100f, _groundLayerMask))
        { 
            _mouseHitPosition = hitInfo.point;
        }

        if (Input.GetMouseButtonDown(0))  
            _agentCharacterController.SetTarget(_mouseHitPosition);

    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_mouseHitPosition, 0.1f);
        }
    }
}
