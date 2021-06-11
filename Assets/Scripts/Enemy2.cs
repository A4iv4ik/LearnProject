using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour

{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject magic;
    [SerializeField] private GameObject Magicstuf;
    [SerializeField] private AudioSource Deathsound;
    [SerializeField] private AudioSource AttackSound;
    [SerializeField] private float Health=20;
    [SerializeField] private AudioSource getdamage;
    [SerializeField]private bool hurt;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject HProtater;
    private Color color;
    private bool attackcd=true;
    private Vector3 _targetpoint;
    int index;
    [SerializeField]private bool istarget;

    void Start()
    {
        slider.maxValue = Health;
        StartCoroutine(Fire());
        navMeshAgent.SetDestination(waypoints[0].position);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        slider.value = Health;
        HProtater.transform.LookAt(_player);
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
                Deathsound.Play();
                StartCoroutine(Death());
            }
        }
        
    }
    private void Attack()
    {
        AttackSound.Play();
    }
    private IEnumerator Fire()
        {
            while (true)
            {
             yield return new WaitForSeconds(1f);
                if (istarget)
                {
                    Instantiate(magic, Magicstuf.transform.position+transform.forward, Magicstuf.transform.rotation);
                    AttackSound.Play();
                }
            }
            
        }
    private IEnumerator Getattack()
    {
        
        yield return new WaitForSeconds(1f);
        hurt = false;
        attackcd = true;
    }
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        Object.Destroy(gameObject);
    }
}


