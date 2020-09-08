using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rbСarrier;
    [SerializeField]
    private GameObject _roket;
    [SerializeField]
    private Transform _shotPos;

    [SerializeField]
    private float _powerRecoil, _timeBeforShotConst;
    private float _timeBeforShot;

    void Start()
    {
    }

    void FixedUpdate()
    {
        if (_timeBeforShot>0)
        {
            _timeBeforShot -= Time.fixedDeltaTime;
        }
    }
    public void Shot()
    {
        if (_timeBeforShot<=0)
        {
            _rbСarrier.AddForce(-transform.forward * 200, ForceMode.Acceleration);
            Instantiate(_roket, _shotPos.position, transform.rotation);
            _timeBeforShot = _timeBeforShotConst;
        }
    }
}
