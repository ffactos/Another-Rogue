using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	
	public float maxHealth = 200f;
	public float currentHealth;
	public GameObject dieGFX;
	public GameObject oin;
	public int oinAmmount;
	public int minAmmount;
	public PlayerStats playerStats;
	public Text text;
	public bool died = false;
	public float angleRange = 50f;
	
	void Awake()
	{
		
		currentHealth = maxHealth;
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		text = GameObject.FindGameObjectWithTag("Score Int").GetComponent<Text>();
		
	}
	
	public void GetDamage(float dmg)
	{
		
		currentHealth -= dmg;
		
		Debug.Log(dmg);
		
		if(currentHealth < 0)
		{
			if(!died)
			{
				
				Die();
				died = true;
				
			}
			
		}
		
	}
	
	public void Die()
	{
		
		GameObject dieEffect = Instantiate(dieGFX, transform.position, transform.rotation);
		playerStats.Oins += 5;
		text.text = playerStats.Oins.ToString();
		int randomOins = Random.Range(minAmmount, oinAmmount);
		
		for(int i = 0; i < randomOins; i++)
		{
			
			float angle = Random.Range(-angleRange, angleRange);
			Vector2 force = new Vector2(angle, 50f);
			GameObject createdOin = Instantiate(oin, transform.position, transform.rotation);
			createdOin.GetComponent<Rigidbody2D>().AddForce(force);
			
		}
		
		Destroy(gameObject);
		
	}
	
}
