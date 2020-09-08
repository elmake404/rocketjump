using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float _speed, _radius, _forse;
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
            && hit.collider.tag == "Wall")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
            foreach (var c in colliders)
            {
                if (c.tag == "Player")
                {
                    var Player = c.GetComponent<Rigidbody>();
                    Player.AddExplosionForce(_forse, hit.point, _radius,0,ForceMode.Acceleration);
                }
            }
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

}
