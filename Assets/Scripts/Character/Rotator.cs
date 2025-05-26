using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Mover _mover;
    private Quaternion leftRotation = Quaternion.Euler(0, 180, 0);
    private Quaternion rightRotation = Quaternion.identity;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        float horizontalDirection = _mover.HorizontalDirection;

        if (horizontalDirection > 0)
        {
            transform.rotation = rightRotation;
        }
        else if (horizontalDirection < 0)
        {
            transform.rotation = leftRotation;
        }
    }
    
    public void RotateCharacter()
    {
        _mover.ResetDirection();

        if(transform.rotation.y == 0)
        {
            transform.rotation = leftRotation;
        }
        else
        {
            transform.rotation = rightRotation;
        }
    }
}
