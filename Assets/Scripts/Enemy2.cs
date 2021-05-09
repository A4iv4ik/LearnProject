using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour

{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject magic;
    [SerializeField] private GameObject Magicstuf;
    [SerializeField] private float Health=20;
    [SerializeField] private AudioSource getdamage;
    [SerializeField]private bool hurt;
    private Color color;
    private bool attackcd=true;
    private Vector3 _targetpoint;
    int index;
    [SerializeField]private bool istarget;

    void Start()
    {
        StartCoroutine(Fire());
        navMeshAgent.SetDestination(waypoints[0].position);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) == false&&attackcd)
        {
            StartCoroutine(Getattack());
            hurt = true;
            attackcd = false;
        }
        RaycastHit hit;

        var startPos = transform.position;


        var rayCast = Physics.Raycast(transform.position, _player.position - startPos, out hit, Mathf.Infinity);

        if (rayCast)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                color = Color.green;
                transform.LookAt(_player);
                istarget = true;

            }
            else
            {
                color = Color.red;
                if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance * 2)
                {
                    index = (index + 1) % waypoints.Length;
                    _targetpoint = waypoints[index].position;
                }
                istarget = false;
            }
            Debug.DrawRay(startPos, _player.position - startPos, color);

            navMeshAgent.SetDestination(_targetpoint);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        
        if (other.tag == "Enemy weapon" && hurt && attackcd==false)
        {
            Health -= 5*Charapter.UPdamage;
            getdamage.Play();
            hurt = false;
            if (Health <= 0)
            {
                Charapter.Souls++;
                Object.Destroy(gameObject);
            }
        }
        
    }
    private IEnumerator Fire()
        {
            while (true)
            {
             yield return new WaitForSeconds(3f);
                if (istarget)
                {
                    Instantiate(magic, Magicstuf.transform.position+transform.forward, Magicstuf.transform.rotation);
                }
            }
            
        }
    private IEnumerator Getattack()
    {
        
        yield return new WaitForSeconds(0.5f);
        hurt = false;
        attackcd = true;
    }
}

