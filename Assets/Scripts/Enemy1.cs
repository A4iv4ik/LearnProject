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
    [SerializeField]private float Health=50f;
    [SerializeField]private AudioSource getdamage;
    private Color color;
    private Vector3 _targetpoint;
    [SerializeField]private bool hurt;
    int index;
    

    void Start()
    {
        _animator = GetComponent<Animator>();
        navMeshAgent.SetDestination(waypoints[0].position);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Move();
        if (Input.GetMouseButtonDown(0))
        {
            hurt = true;
            StartCoroutine(Getattack());
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy weapon"&&hurt)
        {
            Health -= 5;
            getdamage.Play();
            hurt = false;
            if (Health<=0)
            {
                Object.Destroy(gameObject);
            }
        }
        if (other.tag=="Player")
        {
            
            _animator.SetTrigger("Attack");
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
            _animator.SetBool("Run",true);
        }
    }
    private IEnumerator Getattack()
    {

        yield return new WaitForSeconds(0.5f);
        hurt = false;
    }

}

