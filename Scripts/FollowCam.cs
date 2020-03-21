using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    
    [SerializeField]Transform target;
    [SerializeField]Vector3 defaultDistance = new Vector3(0f, 2f, -10f);
    [SerializeField]float distanceDamp = 10f;
    [SerializeField]float rotationalDamp = 10f;


    Transform myT;
    public Vector3 velocity = Vector3.one;


    void Awake()
    {
    	myT = transform;

    }

    void LateUpdate()
    {
        if(!FindTarget())
            return;

    	SmoothFollow();
    	// Vector3 toPos = target.position + (target.rotation * defaultDistance);
    	// Vector3 curPos = Vector3.Lerp(myT.position, toPos, distanceDamp * Time.deltaTime);
    	// myT.position = curPos;

    	// Quaternion toRot = Quaternion.LookRotation(target.position - myT.position, target.up);
    	// Quaternion curRot = Quaternion.Slerp(myT.rotation, toRot, rotationalDamp * Time.deltaTime);
    	// myT.rotation = curRot;
    }


    void SmoothFollow()
    {
    	Vector3 toPos = target.position + (target.rotation * defaultDistance);
    	Vector3 curPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp);
    	myT.position = curPos;

    	myT.LookAt(target, target.up);
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

}
