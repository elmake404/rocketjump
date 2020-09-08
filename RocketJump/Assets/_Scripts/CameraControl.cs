using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Player _player;
    private Vector3 _offset;
    [SerializeField]
    private Transform _protractor;
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
        if (Input.GetMouseButton(0))
        {
            float Z = _protractor.transform.position.z - _cam.transform.position.z;

            _currentPos = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Z));

            _protractor.transform.LookAt(_currentPos);
            _player.ShotDirection(_protractor.eulerAngles);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            _player.ShotDirection(_protractor.eulerAngles);

        }
    }

    void FixedUpdate()
    {
        Vector3 Current = transform.position;
        Current.y = (_player.transform.position - _offset).y;
        transform.position = Vector3.Slerp(transform.position,Current,0.1f);
    }
}
