using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    [SerializeField] GameObject HideWall;
    [SerializeField] GameObject slider;
    [SerializeField] Transform cameraview;

    private void Awake()
    {
        slider.SetActive(false);
        HideWall.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        slider.SetActive(true);
        HideWall.SetActive(true);
        Destroy(gameObject);
        cameraview.localRotation = new Quaternion(0.20f, cameraview.localRotation.y, 0, 1);
    }
}
