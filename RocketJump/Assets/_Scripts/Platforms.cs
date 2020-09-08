using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    [SerializeField]
    private Collider _collider;

    private void FixedUpdate()
    {
        CalculatePosition();
    }
    private void CalculatePosition()
    {
        Vector3 Pos = Player.TransformMain.position;
        Pos.y -= 1;
        _collider.isTrigger = transform.position.y > Pos.y;
    }
    //[ContextMenu("collider")]
    //private void Colider()
    //{
    //    _collider = GetComponent<Collider>();
    //}
}
