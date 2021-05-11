using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : MonoBehaviour
{
    [SerializeField] float distance = 2;
    [SerializeField] private KeyCode key = KeyCode.F;
    [SerializeField] private GameObject ThisPanel;
    private bool talking=false;
    Transform _player;
    static bool Iswater;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ThisPanel.SetActive(false);
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.position) < distance && Input.GetKeyDown(key)&&talking==false)
        {
            ThisPanel.SetActive(true);
            Time.timeScale = 0;
            talking = true;
        }
        else
        if (Input.GetKeyDown(key)&&talking)
        {
            Time.timeScale = 1;
            ThisPanel.SetActive(false);
            talking = false;
            Dialog.i = 0;
        }
    }

        

}
