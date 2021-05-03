using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Color color;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private GameObject magic;
    bool istarget;
    WaypointsPatrol script;
    private Component f;
    private void Awake()
    {
        script = gameObject.GetComponent<WaypointsPatrol>();
        StartCoroutine("Fire");
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        RaycastHit hit;

        var startPos = transform.position;
        var dir = _player.position - startPos;

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
                istarget = false;
            }
        }
        Debug.DrawRay(startPos, _player.position - startPos, color);
    }
    private IEnumerable Fire()
    {
        while (true)
        {
            if (istarget)
            {
                Instantiate(magic, transform.position + transform.forward * 1.5f, transform.rotation);
            }
        }
    }
        
}

