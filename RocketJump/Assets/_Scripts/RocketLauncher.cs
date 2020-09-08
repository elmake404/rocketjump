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
    private float _powerRecoil;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Shot()
    {
        _rbСarrier.velocity = -transform.forward * 2;
        Instantiate(_roket,_shotPos.position,transform.rotation);
    }
}
