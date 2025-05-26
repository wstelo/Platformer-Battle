using System.Collections;
using UnityEngine;

public class EnemyAreaViewer : MonoBehaviour
{
    
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _distance;
    [SerializeField] private float _circleRadius = 2;
    [SerializeField] private float _offsetForStartPoint = 1;

    private Vector2 _circlePosition;
    private Vector3 _startPointToRay;
    private Collider2D hit = null;
    private Collider2D _currentTarget = null;
    private Rotator _rotator;
    private float _checkDelay = 0.25f;
    private Coroutine _coroutine = null;

    public Collider2D CurrentTarget { get { return _currentTarget; } }

    private void Awake()
    {
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        _circlePosition = transform.position;
        _startPointToRay = transform.position;

        if (_rotator.IsRight)
        {
            _circlePosition.x += _distance;
            _startPointToRay.x += _offsetForStartPoint;
        }
        else
        {
            _circlePosition.x -= _distance;
            _startPointToRay.x -= _offsetForStartPoint;
        }    
        
        if(_coroutine == null)
        {
            _coroutine = StartCoroutine(CheckAreaAfterTime());
        }
    }

    public IEnumerator CheckAreaAfterTime()
    {
        var wait = new WaitForSeconds(_checkDelay);

        while (enabled)
        {
            Collider2D hit = Physics2D.OverlapCircle(_circlePosition, _circleRadius, _playerLayer);

            if (hit != null)
            {
                RaycastHit2D Ray = Physics2D.Raycast(_startPointToRay, hit.transform.position - _startPointToRay, Mathf.Infinity, _playerLayer | _groundLayer);

                if (((1 << Ray.collider.gameObject.layer) & _playerLayer.value) != 0)
                {
                    _currentTarget = Ray.collider;
                }
                else
                {
                    _currentTarget = null;
                }
            }
            else
            {
                _currentTarget = null;
            }

            yield return wait;
        }
    }

    public Collider2D GetTarget()
    {
        return _currentTarget;
    }

    private void OnDrawGizmos()
    {
        Color colorRed = new Color(1f, 0f, 0f, 0.3f);
        Color colorGreen = new Color(0f, 1f, 0f, 0.3f);
        Gizmos.color = _currentTarget ? colorGreen : colorRed;
        Gizmos.DrawSphere(_circlePosition, _circleRadius);

        if(hit != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_startPointToRay, hit.transform.position);
        }
    }
}
