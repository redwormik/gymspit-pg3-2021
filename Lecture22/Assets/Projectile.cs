using UnityEngine;


public class Projectile : MonoBehaviour
{
	public Score score;

	public float minX;

	public float maxX;

	public float minY;

	public float maxY;


	// Start is called before the first frame update
	void Start()
	{
	}


	// Update is called once per frame
	void Update()
	{
		if (
			transform.position.x < minX ||
			transform.position.x > maxX ||
			transform.position.y < minY ||
			transform.position.y > maxY
		) {
			Object.Destroy(gameObject);
		}
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.gameObject.tag);

		if (other.gameObject.tag == "Item")
		{
			other.gameObject.SetActive(false);
			score.AddPoint();
		}

		Object.Destroy(gameObject);
	}


	private void OnCollisionEnter2D(Collision2D other)
	{
		Object.Destroy(gameObject);
	}
}
