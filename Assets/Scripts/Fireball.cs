using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fireball : MonoBehaviour
{
    private Rigidbody rg;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.AddForce(Vector3.forward * 30, ForceMode.Impulse);
    }

    void Update()
    {
        
    }
}
