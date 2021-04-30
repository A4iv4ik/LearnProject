using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float _MouseSensetive;
    [SerializeField] private Transform _camera;
    Vector3 _direction = Vector3.zero;
    float _angle;

    void Update()
    {
        
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _angle = Input.GetAxis("Mouse X");
        Camerarotator();
    }
    private void FixedUpdate()
    {
        Move();
        
    }
    private void Camerarotator()
    {
        _camera.transform.Rotate(new Vector3(0f, _angle*_MouseSensetive*Time.fixedDeltaTime, 0f));
    }
    private void Move()
    {
        var _speed = _direction * Time.fixedDeltaTime * speed;
        player.transform.Translate(_speed);
    }

}

