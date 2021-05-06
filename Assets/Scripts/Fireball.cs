using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fireball : MonoBehaviour
{
    private Rigidbody rg;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.AddForce(transform.forward * 30, ForceMode.Impulse);
        //StartCoroutine(Destroy());
    }
    private void OnTriggerEnter(Collider other)
    {
        Object.Destroy(gameObject);
    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        Object.Destroy(gameObject);
    }
}

