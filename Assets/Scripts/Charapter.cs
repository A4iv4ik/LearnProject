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
    [SerializeField] private AudioSource swordsound;
    [SerializeField] private AudioSource fight;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject magic;
    [SerializeField] private Animator _animator;
    [SerializeField] private float health = 100f;
    private bool ishield;
    Component sword;
    [SerializeField] bool rayCast;
    Vector3 _direction = Vector3.zero;
    Quaternion m_Rotation;
    private float damage;
    float ang;
    float _angle;
    private Rigidbody rg;
    private bool up = false;

    private void Awake()
    {
        
        rg = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
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
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Attack");
            swordsound.Play();
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
        if (_direction.x == 1)
        {
        
            ang = 90;
            //player.transform.localRotation = Quaternion.Lerp(player.transform.localRotation, Quaternion.Euler(0, 90, 0), Time.fixedDeltaTime * 10f);
        }
        if (_direction.x == -1)
        {
            ang = 270;
            //player.transform.localRotation = Quaternion.Lerp(player.transform.localRotation, Quaternion.Euler(0, 270, 0), Time.fixedDeltaTime * 10f);
        }
        if (_direction.z == 1)
        {
            ang = 0;
            //player.transform.localRotation = Quaternion.Lerp(player.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.fixedDeltaTime * 10f);
        }
        if (_direction.z == -1)
        {
            ang = 180;
            //player.transform.localRotation = Quaternion.Lerp(player.transform.localRotation, Quaternion.Euler(0, 180, 0), Time.fixedDeltaTime * 10f);
        }
        player.transform.localRotation = Quaternion.Lerp(player.transform.localRotation, Quaternion.Euler(0, ang, 0), Time.fixedDeltaTime * 10f);

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
            Object.Destroy(other);
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
}

