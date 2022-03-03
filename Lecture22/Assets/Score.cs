using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
	public Text scoreText;

	private int score = 0;


	// Start is called before the first frame update
	public void Start()
	{
		UpdateScore();
	}


	// Update is called once per frame
	public void AddPoint()
	{
		score += 1;
		UpdateScore();
	}


	private void UpdateScore()
	{
		scoreText.text = string.Format("Score: {0}", score);
	}
}
