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
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject magic;
    Vector3 _direction = Vector3.zero;
    
    float _angle;
    private Rigidbody rg;
    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _angle = Input.GetAxis("Mouse X");
        Camerarotator();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(prefab,player.transform.position-transform.forward*1.5f,Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(magic, player.transform.position + transform.forward * 1.5f, player.transform.rotation);
        }
        if (Input.GetButtonDown("Jump"))
        {
           
            rg.AddForce(Vector3.up*4f, ForceMode.Impulse);
        }
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

