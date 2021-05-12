using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]float distance = 2;
    [SerializeField]private TextGenerator text ;
    [SerializeField] private KeyCode key = KeyCode.F;
    [SerializeField] private AudioSource take;
    [SerializeField] private GameObject ThisPanel;
     Transform _player;
    [SerializeField] GameObject Prefab;
    private bool keyactive;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ThisPanel.SetActive(false);
        keyactive = true;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.position) < distance && Input.GetKeyDown(key))
        {
            CloseDoor.KeyDoor[1] = true;
            take.Play();
            Instantiate(Prefab, transform.parent);
            gameObject.SetActive(false);
            keyactive = false;
        }
        if (Vector3.Distance(transform.position, _player.position) < distance)
        {
            ThisPanel.SetActive(true);
        }
      if (Vector3.Distance(transform.position, _player.position) > distance)
      {
           ThisPanel.SetActive(false);
      }
      if (keyactive == false)
        {
            ThisPanel.SetActive(false);
        }
    }
}
