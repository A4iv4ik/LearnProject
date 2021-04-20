using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject player;
    public float speed = 2f;
    private Vector3 _direction = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        player=(GameObject)this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    _direction.z = 1;
        //}
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        
    }
    private void FixedUpdate()
    {
        var _speed = _direction.normalized * Time.fixedDeltaTime * speed;
        player.transform.Translate(_speed);
    }
}
