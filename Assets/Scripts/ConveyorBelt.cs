using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float velocity;
    // Direction that the conveyer belt pushes objects.
    [Tooltip("Local direction does this push objects.")]
    [SerializeField] private RelativeDirection direction = RelativeDirection.Down;
 
    public enum RelativeDirection
    {
        Up,
        Down,
        Left,
        Right,
        Forward,
        Backward
    }

    // Rigidbody associated with conveyer belt.
    private Rigidbody body;

    /// <summary>
    /// Position of the conveyer belt.
    /// </summary>
    private Vector3 pos;

    /// <summary>
    /// Awake event to initialize belt configuration.
    /// </summary>
    public void Awake()
    {
        this.body = GetComponent<Rigidbody>();
        pos = transform.position;
    }
    /// <summary>
    /// Fixed update to move the belt and pull objects along with it.
    /// </summary>
    public void FixedUpdate()
    {
        if (body != null)
        {
            Vector3 movement = velocity * GetDirection() * Time.fixedDeltaTime;
            transform.position = pos - movement;
            body.MovePosition(pos);
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if(collision.rigidbody != null && !collision.rigidbody.isKinematic)
        {
            Vector3 movement = velocity * GetDirection() * Time.deltaTime;
            collision.gameObject.GetComponent<Rigidbody>().MovePosition(collision.gameObject.transform.position + movement);
        }
    }

    public Vector3 GetDirection()
    {
        switch(this.direction)
        {
            case RelativeDirection.Up:
                return transform.up;
            case RelativeDirection.Down:
                return -transform.up;
            case RelativeDirection.Left:
                return -transform.right;
            case RelativeDirection.Right:
                return transform.right;
            case RelativeDirection.Forward:
                return transform.forward;
            case RelativeDirection.Backward:
                return -transform.forward;
        }
        return transform.forward;
    }
}
