using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    [SerializeField]
    private Collider _collider;
    void Start()
    {
        _collider.isTrigger = true;
    }

    void Update()
    {
        CalculatePosition();
    }
    private void CalculatePosition()
    {
        Vector3 Pos = Player.TransformMain.position;
        Pos.y -= 1;
        if (transform.position.y<=Pos.y)
        {
            _collider.isTrigger = false;
        }
    }
    //[ContextMenu("collider")]
    //private void Colider()
    //{
    //    _collider = GetComponent<Collider>();
    //}
}
