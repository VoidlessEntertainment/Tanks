using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

	private TankTurret_Pivot pivot;

	void Awake()
	{
		pivot = GetComponent<TankTurret_Pivot>();
	}

	void Update()
	{
		HandleInput();
	}

	void HandleInput()
	{
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.back);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(Vector3.down);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(Vector3.up);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			pivot.transform.Rotate(Vector3.down);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			pivot.transform.Rotate(Vector3.up);
		}
		if (Input.GetKey(KeyCode.Space))
		{
			Fire();
		}
	}

	void Fire()
	{
		
	}

}
