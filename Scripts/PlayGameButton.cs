using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayGameButton : MonoBehaviour
{
	public AudioSource crashSound;

	// void Awake()
	// {
	// 	crashSound = GetComponent<AudioSource>();
	// }

	public void mysound(){
		crashSound.Play();
	}
	
	public void Click()
	{
		      
		EventManager.StartGame();
	}
}
