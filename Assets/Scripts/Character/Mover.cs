using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public float HorizontalDirection { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 velocity, float moveSpeed)
    {
        _rigidbody.velocity = velocity * moveSpeed;
    }

    public void Move(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    public void SetDirection(float direction)
    {
        HorizontalDirection = direction;
    }

    public void ResetDirection()
    {
        HorizontalDirection = 0;
    }
}
