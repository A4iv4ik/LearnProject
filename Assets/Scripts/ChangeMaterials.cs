using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{
    public Material[] materialArray;

    public int pointer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pointer >= materialArray.Length())
        {
            Debug.Log("Error!");
            pointer = 0;
        }
        else
        {

            gameObject.renderer.material = materialArray[pointer];
        }
}
