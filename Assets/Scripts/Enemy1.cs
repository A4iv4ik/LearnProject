using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    private Transform _player;
    private float Health=20f;
    private Color color;
    private Vector3 _targetpoint;
    private bool hurt;
    [SerializeField]private AudioSource getdamage;
    int index;
    

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Move();
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Getattack());
            hurt = true;
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
                if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance * 2)
                {
                    index = (index + 1) % waypoints.Length;
                    _targetpoint = waypoints[index].position;
                }

            }
            Debug.DrawRay(startPos, _player.position - startPos, color);

            navMeshAgent.SetDestination(_targetpoint);
        }
    }
    private IEnumerator Getattack()
    {

        yield return new WaitForSeconds(0.5f);
        hurt = false;
    }

}

