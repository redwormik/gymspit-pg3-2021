using UnityEngine;


public class Controls : MonoBehaviour
{
	public Rigidbody2D rigidBody;

	public GameObject projectilePrefab;

	public Score score;

	public float speed;

	public float projectileSpeed;


	// Start is called before the first frame update
	void Start()
	{
	}


	// Update is called once per frame
	void Update()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float moveScroll = Input.GetAxis("Mouse ScrollWheel");

		// rigidBody.position += new Vector2(moveHorizontal, moveVertical) * speed * Time.deltaTime;
		// rigidBody.velocity += new Vector2(moveHorizontal, moveVertical) * speed * Time.deltaTime;
		rigidBody.AddForce(new Vector2(moveHorizontal, moveVertical) * speed * Time.deltaTime);

		// rigidBody.rotation += moveScroll * speed * Time.deltaTime;
		// rigidBody.angularVelocity += moveScroll * speed * Time.deltaTime;
		rigidBody.AddTorque(moveScroll * speed * Time.deltaTime);

		if (Input.GetButtonDown("Fire1")) {
			Vector3 mousePosition = Input.mousePosition;
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
			Vector2 direction = new Vector2(worldPosition.x, worldPosition.y) - rigidBody.position;
			float rotationAngle = Vector2.SignedAngle(direction, Vector2.up);
			Quaternion rotation = Quaternion.Euler(0, 0, rotationAngle);

			GameObject projectile = Object.Instantiate(projectilePrefab, rigidBody.position + direction.normalized, rotation);
			projectile.GetComponent<Projectile>().score = score;
			projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(
				Mathf.Sin(Mathf.Deg2Rad * rotationAngle),
				Mathf.Cos(Mathf.Deg2Rad * rotationAngle)
			) * projectileSpeed;
		}
	}
}