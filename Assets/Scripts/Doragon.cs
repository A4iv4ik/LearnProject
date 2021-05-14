using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Doragon : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource getdamage;
    [SerializeField] private Slider Slider;
    [SerializeField] private GameObject magic;
    [SerializeField] private GameObject Magicstuf;
    [SerializeField] private GameObject[] Soplo;
    [SerializeField] private GameObject Head;
    [SerializeField] private AudioSource StartRoarSound;
    [SerializeField] private AudioSource Attack1Sound;
    [SerializeField] private AudioSource Attack2Sound;
    [SerializeField] private AudioSource Attack3Sound;
    [SerializeField] private AudioSource DeathSound;
    [SerializeField] private AudioSource WalkingSound;
    [SerializeField] private GameObject FivthWall;
    private bool at1=true;
    private bool at2=true;
    private bool at3=true;
    private bool sleep=true;
    private bool walk=false;
    [SerializeField]private float dragonhealth=1000;
    private float distance;
    private bool hurt;
    private bool attackcd = true;
    private bool FireOn;
    public static bool SL; 
    

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Slider.maxValue = dragonhealth;
    }
    private void FixedUpdate()
    {
        if (SL)
        {
            dragonhealth = 1000;
            SL = false;
            _animator.SetTrigger("Chill");
            _animator.SetTrigger("UnChill");
            _animator.SetTrigger("ThirdAttack");
        }
        if (walk&&dragonhealth>0)
        {

        transform.LookAt(_player);
        }
    }
    private void Update()
    {
        Slider.value = dragonhealth;
        if(Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) == false && attackcd)
        {
            hurt = true;
            attackcd = false;
            StartCoroutine(Getattack());
        }
        distance = Vector3.Distance(transform.position, _player.position);
        if (distance>20)
        { 
            _animator.SetBool("Walk",true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }

        if (distance <8f&&at1)
        {
            _animator.SetTrigger("FirstAttack");
            at1 = false;
            at2 = true;
        }
        if (distance < 13f && distance>8f && at2)
        {
            _animator.SetTrigger("SecondAttack");
            StartCoroutine(Atack2());
            at2 = false;
            at3 = true;
            at1 = true;
        }
        else StopCoroutine(Atack2());
        if (distance > 13f && distance < 20 && at3)
        {
            _animator.SetTrigger("ThirdAttack");
            at3 = false;
            at2 = true;
            at1 = true;
        }
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy weapon" && hurt && attackcd == false)
        {
            dragonhealth -= 5 * Charapter.UPdamage;
            getdamage.Play();
            hurt = false;
            if (dragonhealth <= 0)
            {
                Charapter.Souls++;
                _animator.SetTrigger("Die");
                DeathSound.Play();
                FivthWall.SetActive(false);
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
                FireOn = true;
                if (sleep)
                {
                    StartCoroutine(Chill());
                    _animator.SetTrigger("UnSleep");
                    sleep = false;
                    StartCoroutine(ReadyToWalk());
                }
                if (walk&&dragonhealth>0)
                {
                  
                    navMeshAgent.SetDestination(_player.position);
                }
            }
            else FireOn = false;
        }
        Debug.DrawRay(startPos, _player.position - startPos);
    }
    private void fire2()
    {
        StartCoroutine(Fire());
    }
    private void Attack1()
    {
        Attack1Sound.Play();
    }
    private void Walking()
    {
        WalkingSound.Play();
    }
    private void Attack2()
    {
        Attack2Sound.Play();
    }
    private void Attack3()
    {
        Attack3Sound.Play();
    }

    private void StartRoar()
    {
        StartRoarSound.Play();
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
            if (dragonhealth>0)
            {
            _animator.SetTrigger("Chill");
            walk = false;
            Head.SetActive(false);
            yield return new WaitForSeconds(5f);
            }
            if (dragonhealth>0)
            {
            _animator.SetTrigger("UnChill");
            _animator.SetTrigger("FirstAttack");
            Head.SetActive(true);
            walk = true;
            }
            
        }
    }
    IEnumerator Fire()
    {
        for (int i = 0; i <80 ; i++)
        {
            for (int j = 0; j < Soplo.Length; j++)
            {
            yield return new WaitForSeconds(0.005f);
                Instantiate(magic,Soplo[j].transform.position + transform.forward, Soplo[j].transform.rotation);
            }
        }
    }
    private IEnumerator Getattack()
    {

        yield return new WaitForSeconds(1f);
        hurt = false;
        attackcd = true;
    }
   
       
    }
    
