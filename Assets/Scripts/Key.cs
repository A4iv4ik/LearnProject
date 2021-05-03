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
     Transform _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
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
