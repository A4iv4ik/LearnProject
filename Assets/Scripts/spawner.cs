using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{[SerializeField] GameObject Prefab;
    public static bool[]SP = new bool[5];
    [SerializeField] private int n;
    private void Awake()
    {
        for (int i = 0; i < SP.Length; i++)
        {
            SP[i] = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (SP[n])
        {
            SP[n] = false;
        Instantiate(Prefab, transform.parent);
        }
    }

}
