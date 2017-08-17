using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

	public GameObject bulletPrefab;
	private Transform pivot;
	private Transform tip;
	private GameObject burst;
	private int 
	

	void Update()
	{
		HandleInput();
	}

	void Awake()
	{
		pivot = transform.Find("PivotPoint");
		tip = transform.Find("PivotPoint").Find("TipPoint");
		burst = transform.Find("PivotPoint").Find("TipPoint").Find("MuzzleBurst").gameObject;
		burst.SetActive(false);
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
			pivot.Rotate(Vector3.down);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			pivot.Rotate(Vector3.up);
		}
		if (Input.GetKey(KeyCode.Space))
		{
			Fire();
		}
	}

	void Fire()
	{
		GameObject bullet = Instantiate(bulletPrefab, tip.position, Quaternion.identity) as GameObject;
		bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 30);
		burst.SetActive(true);
		Invoke("hideBurst", 0.2f);
		
	}

	void hideBurst()
	{
		burst.SetActive(false);
	}

}
