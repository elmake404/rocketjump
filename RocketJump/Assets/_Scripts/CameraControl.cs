using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 _startMousePos, _currentMousePos;
    private Player _player;
    private Vector3 _offset;
    private Camera _cam;
    private Vector3 _currentPos;

    void Start()
    {
        _cam = Camera.main;

        _player = Player.PlayerMain;
        _offset = _player.transform.position - transform.position;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startMousePos = _cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButton(0))
        {
            if (_startMousePos== Vector3.zero)
            {
                _startMousePos = _cam.ScreenToViewportPoint(Input.mousePosition);
            }
            _currentMousePos = _cam.ScreenToViewportPoint(Input.mousePosition);
            if ((_currentMousePos - _startMousePos).magnitude>0.01f)
            {
                _player.ShotDirection(_currentMousePos - _startMousePos);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _player._rocketLauncher.Shot();
        }

        //if (Input.GetMouseButton(0))
        //{
        //    float Z = _protractor.transform.position.z - _cam.transform.position.z;

        //    _currentPos = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Z));

        //    _protractor.transform.LookAt(_currentPos);
        //    _player.ShotDirection(_protractor.eulerAngles);

        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    _player.ShotDirection(_protractor.eulerAngles);
        //    _player._rocketLauncher.Shot(_player._rocketLauncher.transform.forward);
        //}
    }

    void FixedUpdate()
    {
        Vector3 Current = transform.position;
        Current.y = (_player.transform.position - _offset).y;
        transform.position = Vector3.Slerp(transform.position,Current,0.1f);
    }
}
