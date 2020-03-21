using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(AudioSource))]
public class Shield : MonoBehaviour
{
    [SerializeField]int maxHealth = 10;
    [SerializeField]int curHealth;
    [SerializeField]float regenerationRate = 2f;
    [SerializeField]int regenerateAmount = 1;
    //[SerializeField]AudioSource deathSound;

    // void Awake(){
    //     deathSound = GetComponent<AudioSource>();
    // }
    void Start()
    {
    	curHealth = maxHealth;
        
    	InvokeRepeating("Regenerate", regenerationRate, regenerationRate);
    }

    void Regenerate()
    {
    	if(curHealth < maxHealth)
    		curHealth +=regenerateAmount;
    	if(curHealth > maxHealth)
    	{
    		curHealth = maxHealth;
    	}
    	EventManager.TakeDamage(curHealth/(float)maxHealth);

    }

    public void TakeDamage(int dmg =1)
    {
    	curHealth -=dmg;
        if(curHealth <0)
            curHealth =0;
        EventManager.TakeDamage(curHealth/(float)maxHealth);

    	if(curHealth <1)
        {
            //deathSound.Play();
            EventManager.PlayerDeath();
            
            GetComponent<Explosion>().BlowUp();

    		
    }
}

}
