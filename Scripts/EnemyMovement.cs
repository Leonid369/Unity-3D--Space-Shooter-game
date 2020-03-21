﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(TrailRenderer))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]Transform target;
    
    [SerializeField]float movementSpeed = 10;
    [SerializeField]float rotationalDamp = .5f;
    [SerializeField]float rayCastOffset = 2.5f;
    [SerializeField]float detectionDistance = 20;
   




    void OnEnable()
    {
    	EventManager.onPlayerDeath += FindMainCamera;
    	EventManager.onStartGame += SelfDestruct;
    }

    void OnDisable()
    {
		EventManager.onPlayerDeath -= FindMainCamera;
		EventManager.onStartGame -= SelfDestruct;
    }


    void SelfDestruct()
    {
    	Destroy(gameObject);
    }

	void Update()
	{
		if(!FindTarget())
			return;
		Pathfinding();
		// Turn();
		Move();
	}

	void Turn()
	{
		Vector3 pos = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(pos);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
	}

	void Move()
	{
		transform.position += transform.forward * movementSpeed * Time.deltaTime;
	}

	void Pathfinding()
	{
		RaycastHit hit;
		Vector3 raycastOffset = Vector3.zero;
		Vector3 left = transform.position - transform.right * rayCastOffset;
		Vector3 right = transform.position + transform.right * rayCastOffset;
		Vector3 up = transform.position + transform.up * rayCastOffset;
		Vector3 down = transform.position - transform.up * rayCastOffset;

		Debug.DrawRay(left, transform.forward * detectionDistance, Color.cyan);
		Debug.DrawRay(right, transform.forward * detectionDistance, Color.cyan);
		Debug.DrawRay(up, transform.forward * detectionDistance, Color.cyan);
		Debug.DrawRay(down, transform.forward * detectionDistance, Color.cyan);

		if(Physics.Raycast(left, transform.forward, out hit, detectionDistance))
			raycastOffset += Vector3.right;
		else if(Physics.Raycast(right, transform.forward, out hit, detectionDistance))
			raycastOffset -= Vector3.right;
		if(Physics.Raycast(up, transform.forward, out hit, detectionDistance))
			raycastOffset -= Vector3.up;
		else if(Physics.Raycast(right, transform.forward, out hit, detectionDistance))
			raycastOffset += Vector3.up;

		if(raycastOffset != Vector3.zero)
		{
			transform.Rotate(raycastOffset * 5f * Time.deltaTime);
		}
		else
		{
			Turn();
		}

	}

	bool FindTarget()
	{
		if(target == null)
		{
			GameObject temp = GameObject.FindGameObjectWithTag("Player");
			if(temp !=null)
				target = temp.transform;
		}

		if(target== null)
			return false;

		return true;
	}

	void FindMainCamera()
	{
		target = GameObject.FindGameObjectWithTag("MainCamera").transform;

	}


}
