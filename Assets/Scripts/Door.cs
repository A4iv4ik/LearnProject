using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	private KeyCode key = KeyCode.F;
	[SerializeField] private AudioSource open;
	[SerializeField] private AudioSource close;
	[SerializeField] private Transform anchor; 
	[SerializeField] private float distance = 2f; 
	[SerializeField] private bool isOpen = false; 
	[SerializeField] private float openAngle = 120f;
	[SerializeField] private float closeAngle = 0f;
	[SerializeField] private float smooth = 2f;
	//[SerializeField] private GameObject Panel;
	private Transform _player;

	void Awake()
	{
		//Panel.SetActive(false);
		isOpen = false;
		_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update()
	{
		if (Vector3.Distance(transform.position, _player.position) < distance && Input.GetKeyDown(key))
		{
            if (isOpen)
            {
				isOpen = false;
				open.Play();
			
            }
            else
            {
			    isOpen = true;
				close.Play();
				
			}
		}
			if (isOpen)
			{
			   
			    Quaternion rotation = Quaternion.Euler(0, openAngle, 0);
				anchor.localRotation = Quaternion.Lerp(anchor.localRotation, rotation, smooth * Time.deltaTime);
			}
			else
			{
				Quaternion rotation = Quaternion.Euler(0, closeAngle, 0);
				anchor.localRotation = Quaternion.Lerp(anchor.localRotation, rotation, smooth * Time.deltaTime);
			}

		//if (Vector3.Distance(transform.position, _player.position) < distance )
      //  {
         	//Panel.SetActive(true)
		//}

	}

	
}