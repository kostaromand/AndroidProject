using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    int speed = 6;
    CameraController cam;
    Rigidbody2D _rigidbody;
    Transform _transform;
    public Vector3 MoveTarget;
    Vector3 oldPosition;
    MoveTargetState moveTargetState = MoveTargetState.Old;
    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true;
        MoveTarget = _transform.position;
        oldPosition = _transform.position;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
        cam.GetComponent<CameraController>().Attach(transform, MoveTarget - transform.position);
    }

    void Move()
    {
        if (moveTargetState == MoveTargetState.Old && Vector3.Magnitude(oldPosition - MoveTarget) < Vector3.Magnitude(_transform.position - MoveTarget))
        {
            _transform.position = oldPosition;
            Idle();
        }
        else
        {
            oldPosition = _transform.position;
            moveTargetState = MoveTargetState.Old;
        }
    }

    void Idle()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Idle();
        Debug.Log("Collision");
    }

    public void goToPoint(Vector3 point)
    {
        if (point == MoveTarget)
            return;
        moveTargetState = MoveTargetState.New;
        MoveTarget = point;
        oldPosition = _transform.position;
        _rigidbody.velocity = Vector3.Normalize((Vector2)MoveTarget - (Vector2)_transform.position)*speed;
    }
    public enum MoveTargetState
    {
        New,
        Old
    }

}

