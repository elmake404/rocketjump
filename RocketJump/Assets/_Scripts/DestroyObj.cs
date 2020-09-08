using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    [SerializeField]
    private float _timeBeforDelite;
    void Start()
    {
        Destroy(gameObject, _timeBeforDelite);
    }
}
