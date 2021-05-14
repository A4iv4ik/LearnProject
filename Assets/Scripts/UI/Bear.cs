using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] float distance = 2;
    [SerializeField] private KeyCode key = KeyCode.F;
    [SerializeField] private AudioSource take;
    Transform _player;
    GameObject Pivo;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Pivo.SetActive(false);
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.position) < distance && Input.GetKeyDown(key))
        {
            Pivo.SetActive(true);
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        Pivo.SetActive(false);
    }
}
