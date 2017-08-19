using UnityEngine;

public class TankController : MonoBehaviour
{

	public GameObject BulletPrefab;
	public float MovementSpeed;
	public float ShootCooldown;
	public float ShootCooldownReset;
	public float deltavx;
	public float deltavz;
	public float velocityLimit = 16;
	
	private Transform _pivot;
	private Transform _tip;
	private GameObject _burst;

	private void Awake()
	{
		_pivot = transform.Find("PivotPoint");
		_tip = transform.Find("PivotPoint").Find("TipPoint");
		_burst = transform.Find("PivotPoint").Find("TipPoint").Find("MuzzleBurst").gameObject;
		_burst.SetActive(false);
		MovementSpeed = 2f;
		ShootCooldown = 0;
		ShootCooldownReset = 1f;
		deltavx = 0;
		deltavz = 0;
	}
	
	private void Update()
	{
		HandleInput();
		Move();
		Cooldown();
	}

	private void Move()
	{
		if (deltavx < 1) {
			transform.Translate(Vector3.back * Time.deltaTime * MovementSpeed * System.Math.Abs(deltavx));
			deltavx += 1;
		}
		if (deltavx > 1) {
			transform.Translate(Vector3.forward * Time.deltaTime * MovementSpeed * System.Math.Abs(deltavx));
			deltavx -= 1;
		}
		if (deltavz < 1) {
			transform.Rotate(Vector3.down * Time.deltaTime * MovementSpeed * System.Math.Abs(deltavz));
			deltavz += 1;
		}
		if (deltavz > 1) {
			transform.Rotate(Vector3.up * Time.deltaTime * MovementSpeed * System.Math.Abs(deltavz));
			deltavz -= 1;
		}
	}

	private void HandleInput()
	{
		if (Input.GetKey(KeyCode.W))
		{
			if (deltavx <= velocityLimit) {
				deltavx += 8;
			} else {
				deltavx = velocityLimit + 8;
			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			if (deltavx >= -velocityLimit) {
				deltavx -= 8;
			} else {
				deltavx = -velocityLimit - 8;
			}
		}
		if (Input.GetKey(KeyCode.A))
		{
			if (deltavz >= -velocityLimit) {
				deltavz -= 8;
			} else {
				deltavz = -velocityLimit - 8;
			}
		}
		if (Input.GetKey(KeyCode.D))
		{
			if (deltavz <= velocityLimit) {
				deltavz += 8;
			} else {
				deltavz = velocityLimit + 8;
			}
		}
		if (Input.GetKey(KeyCode.Q))
		{
			_pivot.Rotate(Vector3.down * Time.deltaTime * MovementSpeed * 24);
		}
		if (Input.GetKey(KeyCode.E))
		{
			_pivot.Rotate(Vector3.up * Time.deltaTime * MovementSpeed * 24);
		}
		if (Input.GetKey(KeyCode.Space) && ShootCooldown <= 0)
		{
			Shoot();
		}
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
		bullet.GetComponent<Rigidbody>().velocity = (_tip.forward * 20) + new Vector3(0, 5f, 0);
		_burst.SetActive(true);
		Invoke("hideBurst", 0.05f);
		ShootCooldown = ShootCooldownReset;
	}

	private void hideBurst()
	{
		_burst.SetActive(false);
	}

}
