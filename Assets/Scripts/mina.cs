using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mina : MonoBehaviour
{
    private Rigidbody rg;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.Translate(transform.forward*-10);
      
    }
    void Update()
    {
        
    }
}
