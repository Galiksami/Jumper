using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAutoClose : MonoBehaviour
{
	public Animator doorAnimator;
	private bool isDoorOpen = false;
	public float autoCloseDelay = 8.0f;

	
	void Start()
	{
		if (doorAnimator == null)
		{
			doorAnimator = GetComponent<Animator>();
		}
	}


	public void OpenDoor()
	{
		isDoorOpen = true;
		doorAnimator.SetBool("IsOpen", true);
		StopAllCoroutines();
		StartCoroutine(CloseDoorAfterDelay()); 
	}

	
	private IEnumerator CloseDoorAfterDelay()
	{
		yield return new WaitForSeconds(autoCloseDelay);
		isDoorOpen = false;
		doorAnimator.SetBool("IsOpen", false);
	}

	
	public void CloseDoor()
	{
		isDoorOpen = false;
		doorAnimator.SetBool("IsOpen", false);
		StopAllCoroutines(); 
	}

	
	public bool IsDoorOpen()
	{
		return isDoorOpen;
	}
}
