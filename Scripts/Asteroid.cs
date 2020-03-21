using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Explosion))]
public class Asteroid : MonoBehaviour
{
	[SerializeField]float minScale = .8f;
	[SerializeField]float maxScale = 1.2f;
	[SerializeField]float rotationOffset = 100f;
	
	AudioSource crashSound;
	public static float destructionDelay = 1.0f;

	Transform myT;
	Vector3 randomRotation;

	void Awake()
	{
		myT = transform;
		crashSound = GetComponent<AudioSource>();
	}
 

 	void Start()
 	{
 		Vector3 scale = Vector3.one;
 		scale.x = Random.Range(minScale,maxScale);
  		scale.y = Random.Range(minScale,maxScale);
 		scale.z = Random.Range(minScale,maxScale);

 		myT.localScale = scale;

 		randomRotation.x = Random.Range(-rotationOffset,rotationOffset);
  		randomRotation.y = Random.Range(-rotationOffset,rotationOffset);
 		randomRotation.z = Random.Range(-rotationOffset,rotationOffset);
 	}

 	void OnCollisionEnter(Collision other)
 	{
 		if (!other.gameObject.CompareTag("Player")) return;
 		// if(!crashSound.isPlaying)
        crashSound.Play();    
 	}

    // Update is called once per frame
    void Update()
    {
     	myT.Rotate(randomRotation * Time.deltaTime);   
    }

	public void SelfDestruct()
	{
		float timer = Random.Range(0,destructionDelay);
		Invoke("GoBoom", timer);
	}
	public void GoBoom()
	{
		// if(!crashSound.isPlaying)
  //           crashSound.Play();      
		GetComponent<Explosion>().BlowUp();
	
	}

   
}
