using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public RocketLauncher _rocketLauncher;
    private Camera _cam;
    [SerializeField]
    private Rigidbody _rb;

    public static Transform TransformMain;
    public static Player PlayerMain;

    void Awake()
    {
        PlayerMain = this;
        TransformMain = transform;
        _cam = Camera.main;
    }

    public void ShotDirection(Vector3 Direction)
    {
        if (Direction.x>=0)
        {
            transform.eulerAngles = new Vector3(0,90,0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
        }

        _rocketLauncher.transform.forward = Direction;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag=="Enemy")
        {
            Repulsion(collision.collider.transform.position);
            _rocketLauncher.PenaltyTime(3);
        }
    }
    private void Repulsion (Vector3 target)
    {
        Vector3 DirectionRepulsion = -(target - transform.position).normalized;
        _rb.AddForce(DirectionRepulsion*500,ForceMode.Acceleration);
    }
}
