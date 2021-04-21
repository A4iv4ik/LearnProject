using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float _MouseSensetive;
    
    Vector3 _direction = Vector3.zero;
    float _angle;
    void Start()
    {
        
    }
    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _angle = Input.GetAxis("Mouse X");
        //_angle.y = Input.GetAxis("Mouse Y");
    }
    private void FixedUpdate()
    {
        Move();
        Camerarotator();
    }
    private void Camerarotator()
    {
        player.transform.Rotate(new Vector3(0f, _angle*_MouseSensetive*Time.fixedDeltaTime, 0f));
    }
    private void Move()
    {
        var _speed = _direction * Time.fixedDeltaTime * speed;
        player.transform.Translate(_speed);
    }
}
