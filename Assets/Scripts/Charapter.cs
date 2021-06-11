using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Charapter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform _camera;
    [SerializeField] private Animator _animator;
    [SerializeField] private Slider slider;
    [SerializeField] private Transform _targ;
    [SerializeField] bool rayCast;
    [SerializeField] private AudioSource swordsound;
    [SerializeField] private AudioSource DeathSound;
    [SerializeField] private GameObject Deathpicture;
    [SerializeField] private float _MouseSensetive;
    [SerializeField] public static int Souls=0;
    [SerializeField] private Text Soul;
    Vector3 _direction = Vector3.zero;
    public static float MAXhealhh = 1000f;
    public static float health = 1000f;
    public static float speed = 4f;
    public static float UPdamage =1f;
    private  bool attackcd=true;
    private bool ishield;
    private float damage;
    float _angle;
    private Rigidbody rg;
    private bool up = false;

    private void Awake()
    {
        Deathpicture.SetActive(false);
        health = MAXhealhh;
        slider.maxValue = health;
        rg = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Soul.text = $"Souls:{Souls}"; 
        slider.value = health;
         rayCast = Physics.Raycast(transform.position+Vector3.up/100,Vector3.down, 0.5f);
        Debug.DrawRay(transform.position,Vector3.down,Color.green,3f);
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _direction=_direction.normalized;
        _angle = Input.GetAxis("Mouse X");
        if (Mathf.Approximately(_direction.x, 0) && Mathf.Approximately(_direction.z, 0))
        {
            _animator.SetBool("IsWalk", false);
        }
        else 
        {
            _animator.SetBool("IsWalk", true);
        }
        Camerarotator();
        Actions();
    }
    private void FixedUpdate()
    {
        Move();
        Death();
    }
    private void Actions()
    {
        if (Input.GetMouseButton(1))
        {
            damage = 1f;
            ishield = false;
            up = !up;
            _animator.SetBool("Block", true);
        }
        else
        {
            ishield = true;
            damage = 5f;
            _animator.SetBool("Block", false);
        }
        if (Input.GetMouseButtonDown(0) && attackcd && ishield)
        {
            _animator.SetTrigger("Attack");
            swordsound.Play();
            transform.localPosition = new Vector3(transform.position.x, transform.position.y + 0.00001f, transform.position.z);
            attackcd = false;
            StartCoroutine(Attackcd());
        }
        if (Input.GetButtonDown("Jump") && rayCast)
        {
            rg.AddForce(Vector3.up * 350f, ForceMode.Impulse);
        }
    }
    private void Camerarotator()
    {
        _targ.localPosition = new Vector3(_direction.x,player.transform.localPosition.y,_direction.z);
        player.transform.LookAt(_targ);
        _camera.transform.Rotate(new Vector3(0f, _angle*_MouseSensetive*Time.fixedDeltaTime, 0f));
    }
    private void Move()
    {
        if (ishield)
        {
        var _speed = _direction * Time.fixedDeltaTime * speed;
        transform.Translate(_speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy weapon")
        {       
            health -=damage;
           
        }
        if (other.tag == "Enemy magic")
        {
            health -= damage*10;

        }
    }
    private void Death()
    {
        if (health<=0)
        {
            StartCoroutine(death());
            Deathpicture.SetActive(true);
            DeathSound.Play();
            Souls = 0;
            UPdamage =1f;
            speed = 4f;
            _animator.SetTrigger("IsDie");
        }
    }
    private IEnumerator death()
    {
        yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private IEnumerator Attackcd()
    {
        yield return new WaitForSeconds(1f);
        attackcd = true;
    }
}


