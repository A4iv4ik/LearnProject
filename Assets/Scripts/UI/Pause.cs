using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField]private bool Ispause=false;
    void Awake()
    {
        Panel.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Ispause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Panel.SetActive(false);
                Time.timeScale = 1;
                Ispause = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Panel.SetActive(true);
            Ispause = true;
            Time.timeScale = 0;
        }
        
    }
}
