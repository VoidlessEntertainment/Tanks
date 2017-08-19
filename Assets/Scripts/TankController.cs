using UnityEngine;

public class TankController : MonoBehaviour
{

	public GameObject BulletPrefab;
	public float MovementSpeed;
	public float ShootCooldown;
	public float ShootCooldownReset;
	
	private Transform _pivot;
	private Transform _tip;
	private GameObject _burst;

	private void Awake()
	{
		_pivot = transform.Find("PivotPoint");
		_tip = transform.Find("PivotPoint").Find("TipPoint");
		_burst = transform.Find("PivotPoint").Find("TipPoint").Find("MuzzleBurst").gameObject;
		_burst.SetActive(false);
		MovementSpeed = 25f;
		ShootCooldown = 0;
		ShootCooldownReset = 1f;
	}
	
	private void Update()
	{
		HandleInput();
		Cooldown();
	}

	private void HandleInput()
	{
		if (Input.GetKey(KeyCode.W))
			transform.Translate(Vector3.forward * Time.deltaTime * MovementSpeed);
		
		if (Input.GetKey(KeyCode.S))
			transform.Translate(Vector3.back * Time.deltaTime * MovementSpeed);
		
		if (Input.GetKey(KeyCode.A))
			transform.Rotate(Vector3.down * Time.deltaTime * MovementSpeed * 3);
		
		if (Input.GetKey(KeyCode.D))
			transform.Rotate(Vector3.up * Time.deltaTime * MovementSpeed * 3);
		
		if (Input.GetKey(KeyCode.LeftArrow))
			_pivot.Rotate(Vector3.down * Time.deltaTime * MovementSpeed * 3);
		
		if (Input.GetKey(KeyCode.RightArrow))
			_pivot.Rotate(Vector3.up * Time.deltaTime * MovementSpeed * 3);
		
		if (Input.GetKey(KeyCode.Space) && ShootCooldown <= 0)
			Shoot();
	}

	private void Cooldown()
	{
		if (ShootCooldown > 0)
		{
			ShootCooldown -= Time.deltaTime;
		}
		else
		{
			ShootCooldown = 0;
		}
	}

	private void Shoot()
	{
		var bullet = Instantiate(BulletPrefab, _tip.position, _tip.rotation);
		bullet.GetComponent<Rigidbody>().velocity = _tip.forward * 20 + new Vector3(0, 5f, 0);
		_burst.SetActive(true);
		Invoke("HideBurst", 0.2f);
		ShootCooldown = ShootCooldownReset;
	}

	private void HideBurst()
	{
		_burst.SetActive(false);
	}

}
