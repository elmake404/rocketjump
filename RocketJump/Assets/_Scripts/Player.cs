using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //private Vector3 _currentPos;
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

    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    float Z = _rocketLauncher.transform.position.z - _cam.transform.position.z;

        //    _currentPos = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Z));

        //    if ((Mathf.Round(transform.eulerAngles.y) == 270 && _currentPos.x > transform.position.x)
        //        || (Mathf.Round(transform.eulerAngles.y) == 90 && _currentPos.x < transform.position.x))
        //    {
        //        transform.Rotate(Vector3.up * 180);
        //    }

        //    _currentPos.z = _rocketLauncher.transform.position.z;
        //    _rocketLauncher.transform.LookAt(_currentPos);
        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    _currentPos.z = transform.position.z;
        //    Vector3 direction = -(_currentPos - transform.position).normalized;
        //    _rocketLauncher.Shot(direction);
        //}
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


        //Vector3 CurrentRotRocket = _rocketLauncher.transform.eulerAngles;
        //Vector3 CurrentRotPlayer = transform.eulerAngles;
        //CurrentRotRocket.x = rotationEuler.x;
        //CurrentRotPlayer.y = rotationEuler.y;
        //_rocketLauncher.transform.eulerAngles = CurrentRotRocket;
        //transform.eulerAngles = CurrentRotPlayer;
    }
}
