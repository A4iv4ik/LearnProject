using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    [SerializeField]private GameObject Panel;
    [SerializeField]private AudioSource EndingSong;
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform TPPoinnt;
    [SerializeField] private GameObject FiwthWall;
    private void Awake()
    {
        Panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TP());
        EndingSong.Play();
        FiwthWall.SetActive(true);
        transform.position = transform.position * 5;
    }
    IEnumerator TP()
    {
        yield return new WaitForSeconds(3.5f);
        Doragon.SL = true;
        _player.transform.position = TPPoinnt.position;
        yield return new WaitForSeconds(11f);
        Panel.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
    
}
