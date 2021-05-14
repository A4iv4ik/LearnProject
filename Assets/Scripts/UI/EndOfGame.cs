using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    [SerializeField]private GameObject Panel;
    private void Awake()
    {
        Panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Panel.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
