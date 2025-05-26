using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Mover _mover;
    private Quaternion leftRotation = Quaternion.Euler(0, 180, 0);
    private Quaternion rightRotation = Quaternion.identity;

    public bool IsRight { get; private set; } = true;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        float horizontalDirection = _mover.HorizontalDirection;

        if (horizontalDirection > 0)
        {
            IsRight = true;
            transform.rotation = rightRotation;
        }
        else if (horizontalDirection < 0)
        {
            IsRight = false;
            transform.rotation = leftRotation;
        }
    }
    
    public void RotateCharacter()
    {
        _mover.ResetDirection();

        if(transform.rotation.y == 0)
        {
            IsRight = false;
            transform.rotation = leftRotation;
        }
        else
        {
            IsRight = true;
            transform.rotation = rightRotation;
        }
    }
}
