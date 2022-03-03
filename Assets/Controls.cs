using UnityEngine;
using UnityEngine.UI;


public class Controls : MonoBehaviour
{
	public Rigidbody2D rigidBody;

	public float speed;

	public Text scoreText;

	private int score = 0;


	// Start is called before the first frame update
	void Start()
	{
		UpdateScore();
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

		// if (rigidBody.position.y > 5) {
		// 	score += 1;
		// 	UpdateScore();
		// }
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.gameObject.tag);

		if (other.gameObject.tag == "Item") {
			other.gameObject.SetActive(false);
			score = score + 1;
			UpdateScore();
		}
	}


	private void UpdateScore()
	{
		scoreText.text = string.Format("Score: {0}", score);
	}
}
