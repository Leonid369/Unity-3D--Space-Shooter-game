using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Light))]
public class Laser : MonoBehaviour
{
	[SerializeField]float laserOffTime = .5f;
	[SerializeField]float maxDistance = 300f;
	[SerializeField]float fireDelay = 2f;

	AudioSource shootSound;
	bool isActive = false;

	LineRenderer lr;
	Light laserLight;
	bool canFire;

	void Awake()
	{
		lr = GetComponent<LineRenderer>();
		laserLight = GetComponent<Light>();
		shootSound = GetComponent<AudioSource>();
	}

	void Start()
	{
		lr.enabled = false;
		laserLight.enabled = false;
		canFire = true;
	}

	// void Update()
	// {
	// 	if (!isActive) return;
		
	// }

	Vector3 CastRay()
	{
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDistance;

		if(Physics.Raycast(transform.position, fwd, out hit))
		{
			//Debug.Log("We hit: " + hit.transform.name);
			SpawnExplosion(hit.point, hit.transform);

			if(hit.transform.CompareTag("Pickup"))
				hit.transform.GetComponent<Pickup>().PickupHit();

			return hit.point;

		}
		
		//Debug.Log("We missed");
		return transform.position + (transform.forward * maxDistance);
			
		
	}

	void SpawnExplosion(Vector3 hitPosition, Transform target)
	{

			Explosion temp = target.GetComponent<Explosion>();
			if(temp != null)
			{
				//temp.IveBeenHit(hitPosition);
				temp.AddForce(hitPosition, transform);
			}
			

	}

	public void FireLaser()
	{
		Vector3 pos = CastRay();
		FireLaser(pos); 
}

	public void FireLaser(Vector3 targetPosition, Transform target = null)
	{
		if(canFire){
			if(target != null){
				SpawnExplosion(targetPosition, target);
				
			}

		lr.SetPosition(0, transform.position);
		lr.SetPosition(1, CastRay());

		lr.enabled = true;
		laserLight.enabled = true;
		if(!shootSound.isPlaying){shootSound.Play();}
		canFire = false;
		Invoke("TurnOffLaser", laserOffTime);
		Invoke("CanFire", fireDelay);
	}
}


	void TurnOffLaser()
	{
		lr.enabled = false;
		laserLight.enabled = false;
	}

	public float Distance
	{
		get { return maxDistance;}
	}

	void CanFire()
	{
		canFire = true;
	}
}
