using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private Vector3 offset;

    // Use this for initialization
    void Start()    
    {
        offset = transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_player != null)
        {
            transform.position = _player.transform.position + offset;
        }

    }
}
