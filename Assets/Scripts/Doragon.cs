using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Doragon : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator _animator;
    private bool at1=true;
    private bool at2=true;
    private bool at3=true;
    private bool sleep=true;
    private bool walk=false;
    private float health;
    private float distance;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
         distance = Vector3.Distance(transform.position, _player.position);
        if (distance>20)
            _animator.SetBool("Walk",true);
        else
            _animator.SetBool("Walk", false);

        if (distance <10f&&at1)
        {
            _animator.SetTrigger("FirstAttack");
            at1 = false;
            at2 = true;
            
        }
        if (distance < 16f && distance>10f && at2)
        {
            _animator.SetTrigger("SecondAttack");
            StartCoroutine(Atack2());
            at2 = false;
            at3 = true;
            at1 = true;
        }
        else StopCoroutine(Atack2());
        if ( distance > 16f && at3)
        {
            
            _animator.SetTrigger("ThirdAttack");
            at3 = false;
            at2 = true;
            at1 = true;
        }
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
                    StartCoroutine(Chill());
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
        while (distance < 16f && distance > 10f)
        {
            yield return new WaitForSeconds(6f);
            if (at2==false)
            {
            _animator.SetTrigger("SecondAttack");

            }

        }
    }
    IEnumerator Chill()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);
            _animator.SetTrigger("Chill");
            walk = false;
            yield return new WaitForSeconds(5f);
            _animator.SetTrigger("UnChill");
            walk = true;
        }
    }
}
