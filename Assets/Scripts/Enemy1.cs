using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Color color;
    [SerializeField] private LayerMask _mask;
     WaypointsPatrol script;
    private void Awake()
    {
          script = gameObject.GetComponent<WaypointsPatrol>();
        
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        RaycastHit hit;

        var startPos = transform.position;
        var dir = _player.position - startPos;

        var rayCast = Physics.Raycast(transform.position, _player.position-startPos, out hit, Mathf.Infinity);

        if (rayCast)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                 color = Color.green;
                transform.LookAt(_player);
                if (Vector3.Distance(transform.position,_player.position)>3f)
                {
                transform.position=Vector3.MoveTowards(transform.position,_player.position,3f*Time.deltaTime);
                }
            }
            else
            {
                color = Color.red;

            }
        }
        Debug.DrawRay(startPos,_player.position - startPos,color);

    }
}
