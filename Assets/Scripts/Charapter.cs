using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Charapter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float _MouseSensetive;
    [SerializeField] private Transform _camera;
    [SerializeField] private AudioSource swordsound;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject magic;
    [SerializeField] private Animator _animator;
    [SerializeField] private Slider slider;
    [SerializeField] private Transform _targ;
    [SerializeField] public static int Souls=0;
    [SerializeField] private Text Soul;
    public static float UPdamage =1f;
    private float UPspeed = 1f;
    private bool attackcd=true;
    private float MAXhealhh = 1000f;
    public float health = 1000f;
    private bool ishield;
    [SerializeField] bool rayCast;
    Vector3 _direction = Vector3.zero;
    private float damage;
    float ang;
    float _angle;
    private Rigidbody rg;
    private bool up = false;

    private void Awake()
    {
        slider.maxValue = health;
        rg = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Soul.text = $"Souls:{Souls}"; //Convert.ToString(Souls);//$"{Souls}";
        slider.value = health;
         rayCast = Physics.Raycast(transform.position+Vector3.up/100,Vector3.down, 0.5f);
        Debug.DrawRay(transform.position,Vector3.down,Color.green,3f);

        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _direction=_direction.normalized;
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
        if (Input.GetButtonDown("Jump")&& rayCast)
        {
            rg.AddForce(Vector3.up*400f, ForceMode.Impulse);
        }
        if (Mathf.Approximately(_direction.x, 0) && Mathf.Approximately(_direction.z, 0))
        {
            _animator.SetBool("IsWalk", false);
        }
        else 
        {
            _animator.SetBool("IsWalk", true);
        }
        if (Input.GetMouseButtonDown(0)&& attackcd && ishield)
        {
            _animator.SetTrigger("Attack");
            swordsound.Play();
            attackcd = false;
            StartCoroutine(Attackcd());
        }
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
       
    }
    private void FixedUpdate()
    {
        Move();
        Death();
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
            health -= damage*3;

        }
    }
    private void Death()
    {
        if (health<=0)
        {
            health = 100;

            StartCoroutine(death());
        }
    }
    private IEnumerator death()
    {
        yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private IEnumerator Attackcd()
    {
        yield return new WaitForSeconds(1f);
        attackcd = true;
    }
    public void DamageUp()
    {
        UPdamage++;
        Souls = Souls - 3;
    }
    public void SpeedUp()
    {
        speed=speed+1f;
        Souls = Souls - 3;
    }
    public void Heal()
    {
        health = health + MAXhealhh * 0.25f;
        Souls = Souls - 2;
    }
}


