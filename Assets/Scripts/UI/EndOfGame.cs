using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    [SerializeField] private GameObject FiwthWall;
    private bool walopen = false;
    private void Awake()
    {
    }
    private void FixedUpdate()
    {
        if (walopen)
        {
            FiwthWall.transform.Translate(0, -0.5f * Time.fixedDeltaTime, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        walopen = true;
        StartCoroutine(OpenWall());
        StartCoroutine(NewScene());
        transform.position = transform.position * 5;
    }
    
    IEnumerator OpenWall()
    {
        yield return new WaitForSeconds(6f);
        walopen = false;
    }
    IEnumerator NewScene()
    {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(3);
    }
}
