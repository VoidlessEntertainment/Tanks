using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

	public TankTurret_Pivot Pivot;
	
	private void Awake()
	{

	}
	
	void Start () {
		
	}
	
	void Update () {
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
			Pivot.transform.Rotate(Vector3.down);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			Pivot.transform.Rotate(Vector3.up);
		}
	}


}
