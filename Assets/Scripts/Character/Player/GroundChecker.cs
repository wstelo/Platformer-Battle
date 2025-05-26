using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _pointPositionY = - 0.3f;
    [SerializeField] private float _rayRadius = 0.3f;

    private Vector2 drawPoint;
    private float _pointPositionX = 0;

    public bool IsGrounded { get; private set; } = false;

    private void Update()
    {
        drawPoint = transform.position + new Vector3(_pointPositionX, _pointPositionY);
        Collider2D hit = Physics2D.OverlapCircle(drawPoint, _rayRadius, _groundLayer);
        IsGrounded = hit != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = IsGrounded ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position + new Vector3(_pointPositionX, _pointPositionY), _rayRadius);
    }
}
