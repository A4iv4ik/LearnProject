using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy1 : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    private Transform _player;
    private Animator _animator;
    [SerializeField]private GameObject Axe;
    [SerializeField]private float Health=50f;
    [SerializeField]private AudioSource getdamage;
    private Color color;
    private Vector3 _targetpoint;
    [SerializeField]private bool hurt;
    int index;
    //private float Souls;
    

    void Start()
    {
        Axe.SetActive(false);
        _animator = GetComponent<Animator>();
        navMeshAgent.SetDestination(waypoints[0].position);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&& Input.GetMouseButton(1)==false)
        {
            hurt = true;
            StartCoroutine(Getattack());
        }
    }
    void FixedUpdate()
    {
        Move();
        

    }

        
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy weapon"&&hurt)
        {
            Health -=5*Charapter.UPdamage;
            getdamage.Play();
            hurt = false;
            if (Health<=0)
            {
                Charapter.Souls ++;
                Object.Destroy(gameObject);
            }
        }
        if (other.tag=="Player")
        {
            
            _animator.SetTrigger("Attack");
            Axe.SetActive(true);
            StartCoroutine(Attack());
        }
        
    }
    private void Move()
    {
        RaycastHit hit;

        var startPos = transform.position;


        var rayCast = Physics.Raycast(transform.position, _player.position - startPos, out hit, Mathf.Infinity);

        if (rayCast)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                color = Color.green;
                transform.LookAt(_player);
                _targetpoint = _player.position;
                
            }
            else
            {
                color = Color.red;
                if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
                {
                    index = (index + 1) % waypoints.Length;
                    _targetpoint = waypoints[index].position;
                }

            }
            Debug.DrawRay(startPos, _player.position - startPos, color);

            navMeshAgent.SetDestination(_targetpoint);
            if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
            {
                _animator.SetBool("Run", true);
            }
            else _animator.SetBool("Run",false);
        }
    }
    private IEnumerator Getattack()
    {

        yield return new WaitForSeconds(0.5f);
        hurt = false;
    }
    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);
        Axe.SetActive(false);
    }
}

