using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CapsuleCollider))]
public class Pickup : MonoBehaviour
{
	static int points = 100;
	[SerializeField]float rotationOffset = 100f;
	bool gotHit = false;
	Vector3 randomRotation;
	
	AudioSource pickSound;
	

	Transform myT;

	void Awake()
	{
		myT = transform;
		pickSound = GetComponent<AudioSource>();
	}



	void Start()
	{
		randomRotation.x = Random.Range(-rotationOffset,rotationOffset);
  		randomRotation.y = Random.Range(-rotationOffset,rotationOffset);
 		randomRotation.z = Random.Range(-rotationOffset,rotationOffset);
	}

	void Update()
	{
		myT.Rotate(randomRotation * Time.deltaTime);   
	}


// void OnCollisionEnter(Collision other)
//  	{
 		// if (!other.gameObject.CompareTag("Player")) return;
 		// if(!crashSound.isPlaying)
   //         crashSound.Play();    
//  	}

	void OnTriggerEnter(Collider col)
	{
		if(col.transform.CompareTag("Player"))
		{
			
		
			if(!gotHit)
			{
				
				PickupHit();
				if(!pickSound.isPlaying){
				   	pickSound.Play();}


			}
			
			
		}
	}

	public void PickupHit()
	{
		if(!gotHit)
		{

			gotHit = true;
			   
			EventManager.ScorePoints(points);
			EventManager.ReSpawnPickup();
			Destroy(gameObject);
		}
		
		
	}



}
