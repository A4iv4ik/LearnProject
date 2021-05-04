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
    private Color color;
    private Vector3 _targetpoint;
    int index;
    private bool istarget;

    void Start()
    {
        StartCoroutine("Fire");
        navMeshAgent.SetDestination(waypoints[0].position);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
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
    private IEnumerable Fire()
        {
            while (true)
            {
             yield return new WaitForSeconds(3f);
                if (istarget)
                {
                    Instantiate(magic, transform.position + transform.forward * 1.5f, transform.rotation);
                }
            }

}

 //   [SerializeField] private Transform _player;
 //   private Color color;
 //   [SerializeField] private LayerMask _mask;
 //   [SerializeField] private GameObject magic;
 //   bool istarget;
 //   WaypointsPatrol script;
 //   private Component f;
 //   private void Awake()
 //   {
 //       script = gameObject.GetComponent<WaypointsPatrol>();
 //       StartCoroutine("Fire");
 //       _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
 //   }
 //   private void FixedUpdate()
 //   {
 //       RaycastHit hit;
 //
 //       var startPos = transform.position;
 //       var dir = _player.position - startPos;
 //
 //       var rayCast = Physics.Raycast(transform.position, _player.position - startPos, out hit, Mathf.Infinity);
 //
 //       if (rayCast)
 //       {
 //           if (hit.collider.gameObject.CompareTag("Player"))
 //           {
 //               color = Color.green;
 //               transform.LookAt(_player);
 //               istarget = true;
 //
 //           }
 //           else
 //           {
 //               color = Color.red;
 //               istarget = false;
 //           }
 //       }
 //       Debug.DrawRay(startPos, _player.position - startPos, color);
 //   }
 //  private IEnumerable Fire()
 //  {
 //       yield return new WaitForSeconds();
 //      while (true)
 //      {
 //          if (istarget)
 //          {
 //              Instantiate(magic, transform.position + transform.forward * 1.5f, transform.rotation);
 //          }
 //      }
 //  }
        
}

