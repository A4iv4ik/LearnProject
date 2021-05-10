using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Doragon : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator _animator;
    private bool at1;
    private bool at2;
    private bool at3;
    private bool sleep=true;
    private bool walk=false;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        var distance = Vector3.Distance(transform.position, _player.position);
        if (distance <8f&&at1)
        {
            _animator.SetTrigger("FirstAttack");
            at1 = false;
            at2 = true;
        }
        if (distance < 12f && distance>8f && at2)
        {
            _animator.SetTrigger("SecondAttack");
            at2 = false;
            at3 = true;
            at1 = true;
        }
        if ( distance > 12f && at3)
        {
            _animator.SetTrigger("ThirdAttack");
            at3 = false;
            at2 = true;
            at1 = true;
        }
    }
    private void FixedUpdate()
    {
        Move();
        
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
                if (sleep)
                {
                    _animator.SetTrigger("UnSleep");
                    sleep = false;
                    StartCoroutine(ReadyToWalk());
                }
                if (walk)
                {
                transform.LookAt(_player);
                navMeshAgent.SetDestination(_player.position);
                }
            }
        }
        Debug.DrawRay(startPos, _player.position - startPos);
    }
    IEnumerator ReadyToWalk()
    {
        yield return new WaitForSeconds(3f);
        walk = true;
    }
    IEnumerator Atack2()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            new WaitForSeconds(3f);
        }
    }
    IEnumerator Atack3()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            new WaitForSeconds(3f);
        }
    }
}
