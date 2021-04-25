using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{[SerializeField] GameObject Prefab;
    bool X = true;
    private void OnTriggerEnter(Collider other)
    {
        if (X)
        {
        Instantiate(Prefab, transform.parent);
            X = false;
        }
    }
}
