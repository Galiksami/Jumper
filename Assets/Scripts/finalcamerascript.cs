using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalcamerascript : MonoBehaviour
{
	public Transform player;
	public float rotationSpeed = 100.0f; 
	public float zoomSpeed = 10f; 
	public float minZoom = 5f; 
	public float maxZoom = 20f; 

	private Vector3 _offset; 

	void Start()
	{
		
		_offset = transform.position - player.position;
	}

	void Update()
	{
		
		float horizontalInput = 0f;
		if (Input.GetKey(KeyCode.A))
		{
			horizontalInput = 1f; 
		}
		else if (Input.GetKey(KeyCode.D))
		{
			horizontalInput = -1f; 
		}

		
		if (Input.GetMouseButton(2)) 
		{
			horizontalInput = Input.GetAxis("Mouse X");
		}

		
		if (horizontalInput != 0)
		{
			Quaternion rotation = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);
			_offset = rotation * _offset;
		}

		
		float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
		_offset += _offset.normalized * scroll;
		_offset = Vector3.ClampMagnitude(_offset, maxZoom);

		
		if (_offset.magnitude < minZoom)
		{
			_offset = _offset.normalized * minZoom;
		}

		
		transform.position = player.position + _offset;
		transform.LookAt(player.position);
	}
}
