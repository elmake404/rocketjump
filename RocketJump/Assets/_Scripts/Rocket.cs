﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float _speed, _radius, _forse;
    [SerializeField]
    private GameObject _explosion;
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speed);
        СollisionСhecking();
    }
    private void СollisionСhecking()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, -transform.forward * 10, Color.yellow);
        if (Physics.Raycast(transform.position + Vector3.back, -transform.forward, out hit, 3)
            && (hit.collider.gameObject.layer == 9 ))
        {
            float ForseExplosion = _forse;
            if (hit.collider.tag == "Platform")
            {
                ForseExplosion *= hit.collider.GetComponent<Platforms>().GetExplosionForceMultiplier();
            }

            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
            foreach (var c in colliders)
            {
                if (c.tag == "Player")
                {
                    var Player = c.GetComponent<Rigidbody>();
                    Player.AddExplosionForce(ForseExplosion, hit.point, _radius, 0, ForceMode.Acceleration);
                }
            }
            Instantiate(_explosion, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

}
