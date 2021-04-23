using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	private KeyCode key = KeyCode.F;
	[SerializeField]private Transform player;
	[SerializeField] private Transform anchor; 
	[SerializeField] private float distance = 2f; 
	[SerializeField] private bool isOpen = false; 
	[SerializeField] private float openAngle = 120f;
	[SerializeField] private float closeAngle = 0f;
	[SerializeField] private float smooth = 2f;

	void Awake()
	{
		isOpen = false;
		
	}

	void Update()
	{
		if (Vector3.Distance(transform.position, player.position) < distance && Input.GetKeyDown(key))
		{
            if (isOpen)
            {
				isOpen = false;
            }
            else
            {
			isOpen = true;
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

			
		
	}

	
}