using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]float distance = 2;
    [SerializeField]private TextGenerator text ;
    [SerializeField] private KeyCode key = KeyCode.F;
    [SerializeField] private AudioSource take;
    public static bool iskay = false;
    [SerializeField] Transform _player;
    //Transform _player = GameObject.FindWithTag("Player").transform;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.position) < distance && Input.GetKeyDown(key))
        {
            iskay = true;
            take.Play();
            gameObject.SetActive(false);
            
        }

    }
}
