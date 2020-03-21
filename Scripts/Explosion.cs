using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
//[RequireComponent(typeof(AudioSource))]
public class Explosion : MonoBehaviour
{

	[SerializeField]GameObject explosion;
    [SerializeField]GameObject blowUp;
	[SerializeField]Rigidbody rigidBody;
	[SerializeField]float laserHitModifier = 100f;
	[SerializeField]Shield shield;

    //AudioSource deathSound;

   

     public void IveBeenHit(Vector3 pos)
    {
    	GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
    	Destroy(go, 6f);

    	if(shield == null)
    		return;

    	shield.TakeDamage();

    }



    void OnCollisionEnter(Collision collision)
    {
    	foreach(ContactPoint contact in collision.contacts)
    		IveBeenHit(contact.point);
        
    }

    public void AddForce(Vector3 hitPosition,Transform hitSource)
    {
        IveBeenHit(hitPosition);
    	//Debug.LogWarning("Adforce:" + gameObject.name + " -> " + hitSource.name);
    	if(rigidBody == null)
    		return;

    	Vector3 forceVector = (hitSource.position - transform.position).normalized;
    	//Debug.Log(forceVector * laserHitModifier);
    	rigidBody.AddForceAtPosition(forceVector * laserHitModifier, hitPosition, ForceMode.Impulse);

    }

   // public void PlayerDied()
   // {
        
   //      BlowUp();
   // }
    public void BlowUp()
    {
        //EventManager.PlayerDeath();
        GameObject temp= Instantiate(blowUp,transform.position,Quaternion.identity) as GameObject;
        
        Destroy(temp, 3f);
        Destroy(gameObject);

    }
}
