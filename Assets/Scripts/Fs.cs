using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fs : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource fight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy weapon")
        {
            fight.Play();


        }
    }
}
