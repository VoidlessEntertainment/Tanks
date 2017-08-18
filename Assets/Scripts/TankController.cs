using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

	public GameObject bulletPrefab;
	private Transform pivot;
	private Transform tip;
	private GameObject burst;
	public float tankSpeed;

	void Awake()
	{
		pivot = transform.Find("PivotPoint");
		tip = transform.Find("PivotPoint").Find("TipPoint");
		burst = transform.Find("PivotPoint").Find("TipPoint").Find("MuzzleBurst").gameObject;
		burst.SetActive(false);
		tankSpeed = 25F;
	}
	
	void Update()
	{
		HandleInput();
	}

	void HandleInput()
	{
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward * Time.deltaTime * tankSpeed);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.back * Time.deltaTime * tankSpeed);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(Vector3.down * Time.deltaTime * tankSpeed * 2);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(Vector3.up * Time.deltaTime * tankSpeed * 2);
		}
		if (Input.GetKey(KeyCode.Q))
		{
			pivot.Rotate(Vector3.down * Time.deltaTime * tankSpeed * 3);
		}
		if (Input.GetKey(KeyCode.E))
		{
			pivot.Rotate(Vector3.up * Time.deltaTime * tankSpeed * 3);
		}
		if (Input.GetKey(KeyCode.Space))
		{
			Shoot();
		}
	}

	void Shoot()
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
