using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
	private DoorAutoClose doorAutoClose;

	void Start()
	{
		doorAutoClose = GetComponent<DoorAutoClose>();
		if (doorAutoClose == null)
		{
			Debug.LogError("DoorAutoClose script not found on the door!");
		}
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform == transform && doorAutoClose != null)
				{
					if (!doorAutoClose.IsDoorOpen())
					{
						doorAutoClose.OpenDoor();
					}
					else
					{
						doorAutoClose.CloseDoor();
					}
				}
			}
		}
	}
}
