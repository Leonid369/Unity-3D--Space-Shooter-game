using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[DisallowMultipleComponent]
public class Score : MonoBehaviour
{
	[SerializeField]Text scoreText;

	[SerializeField]Text hiScoreText;

    
	[SerializeField]int score;
	[SerializeField]int hiScore;

	void Start()
	{
		LoadHiScore();
	}

	void OnEnable()
	{
		EventManager.onStartGame += ResetScore;
		EventManager.onStartGame +=LoadHiScore;
		EventManager.onPlayerDeath += CheckNewHiScore;
		EventManager.onScorePoints += AddScore;
	}


	void OnDisable()
	{
		EventManager.onStartGame -= ResetScore;
		EventManager.onStartGame -=LoadHiScore;
		EventManager.onPlayerDeath -= CheckNewHiScore;
		EventManager.onScorePoints -= AddScore;

	}

	void ResetScore()
	{
		score =0;
		DisplayScore();
	}


	void AddScore(int amt)
	{
		score +=amt;
		DisplayScore();
	}

	void DisplayScore()
	{
		scoreText.text = score.ToString();
	}


	void LoadHiScore()
	{
		hiScore = PlayerPrefs.GetInt("hiScore", 0);
		DisplayHighScore();
	}

	void CheckNewHiScore()
	{
		if(score > hiScore)
			{PlayerPrefs.SetInt("hiScore", score);
			DisplayHighScore();

		}
	}

	void DisplayHighScore()
	{
		hiScoreText.text = hiScore.ToString();
	}

}
