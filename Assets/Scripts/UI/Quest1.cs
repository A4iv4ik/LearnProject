using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : MonoBehaviour
{
    [SerializeField] float distance = 2;
    [SerializeField] private KeyCode key = KeyCode.F;
    [SerializeField] private GameObject ThisPanel;
    [SerializeField] private GameObject ThisPanel2;
    [SerializeField] private GameObject ThisPanel3;
    [SerializeField] private GameObject PanelSsupport;
    [SerializeField] private GameObject Alive;
    [SerializeField] private GameObject NotAlive;
    [SerializeField] private GameObject Bear;
    private bool talking=false;
    public static int dialogNum;
    Transform _player;
    static bool Iswater;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ThisPanel.SetActive(false);
        ThisPanel2.SetActive(false);
        ThisPanel3.SetActive(false);
        PanelSsupport.SetActive(false);
        Alive.SetActive(true);
        NotAlive.SetActive(false);
        Bear.SetActive(false);
    }
    void Update()
    {
        if (dialogNum==2)
        {
            Alive.SetActive(false);
            NotAlive.SetActive(true);

        }
        if (Vector3.Distance(transform.position, _player.position) < distance) PanelSsupport.SetActive(true);
        else PanelSsupport.SetActive(false);
        if (Vector3.Distance(transform.position, _player.position) < distance && Input.GetKeyDown(key)&&talking==false)
        {
            
            switch (dialogNum)
            {
                case 0:
                    ThisPanel.SetActive(true);
                    break;
                case 1:
                    ThisPanel2.SetActive(true);
                    break;
                case 2:
                    ThisPanel3.SetActive(true);
                    break;
            }
            Time.timeScale = 0;
            talking = true;
        }
        else
        if (Input.GetKeyDown(key)&&talking)
        {
            Time.timeScale = 1;
            switch (dialogNum)
            {
                case 0:
                    ThisPanel.SetActive(false);
                    break;
                case 1:
                    ThisPanel2.SetActive(false);
                    CloseDoor.KeyDoor[2] = true;
                    break;
                case 2:
                    ThisPanel3.SetActive(false);
                    Bear.SetActive(true);
                    CloseDoor.KeyDoor[3] = true;
                    break;
            }
            talking = false;
            Dialog.i = 0;
        }
    }

        

}
