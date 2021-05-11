using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private GameObject[] replics;
    [SerializeField] private GameObject button;
    public static int i;
public void dialog()
    {
        i++;
        if (i == replics.Length) button.SetActive(false);
        else button.SetActive(true);
        switch (i)
        {
            case 1:
                replics[1].SetActive(true);
                break; 
            case 2:
                replics[1].SetActive(false);
                replics[2].SetActive(true);
                break;
            case 3:
                replics[2].SetActive(false);
                replics[3].SetActive(true);
                break;
            case 4:
                replics[3].SetActive(false);
                replics[4].SetActive(true);
                break;
            case 5:
                replics[4].SetActive(false);
                replics[5].SetActive(true);
                break;
            case 6:
                replics[5].SetActive(false);
                replics[6].SetActive(true);
                break;
            case 7:
                replics[6].SetActive(false);
                replics[7].SetActive(true);
                break;
        }
    }
}
