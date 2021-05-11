using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doragonfire : MonoBehaviour
{
    [SerializeField] private GameObject[] Soplo;
    [SerializeField] private GameObject magic;
    private void Awake()
    {
        
        StartCoroutine(Fire());
        StartCoroutine(Destroy());
    }
    IEnumerator Fire()
    {
        while (true)
        {

            yield return new WaitForSeconds(0.02f);
            for (int i = 0; i < Soplo.Length; i++)
            {
                Instantiate(magic, Soplo[i].transform.position + transform.forward, Soplo[i].transform.rotation);
            }
        }
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2.2f);
        Destroy(gameObject);
    }
     
}
