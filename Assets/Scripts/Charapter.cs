using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Charapter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float _MouseSensetive;
    [SerializeField] private Transform _camera;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject magic;
    [SerializeField] private Animator _animator;
    [SerializeField]private float health = 100f;

    Vector3 _direction = Vector3.zero;
    float _angle;
    private Rigidbody rg;
    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
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
           
            rg.AddForce(Vector3.up*400f, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            _animator.SetTrigger("New Trigger");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            _animator.SetBool("New Bool", false);
        }
    }
    private void FixedUpdate()
    {
        Move();
        Death();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy weapon")
        {
            health -=5;
            Object.Destroy(other);
        }
    }
    private void Death()
    {
        if (health<=0)
        {
            health = 100;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

