using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float distance = 3f;
    [SerializeField] private AudioSource Gong;
    private KeyCode key = KeyCode.F;
    GameObject[] Rooms;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.position) < distance && Input.GetKeyDown(key))
        {
            Gong.Play();
            for (int i = 0; i < spawner.SP.Length; i++)
            {
                spawner.SP[i] = true;
            }
            Charapter.health = Charapter.MAXhealhh;
            Rooms = GameObject.FindGameObjectsWithTag("Room");
            for (int j = 0; j < Rooms.Length; j++)
            {
                Destroy(Rooms[j]);
            }
          
        }
    }

}
