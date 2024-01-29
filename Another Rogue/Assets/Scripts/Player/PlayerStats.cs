using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

	//public GameObject gameoverLogo;
	public Slider HealthBar;
	public GameObject dieGFX;
	public float maxHealth = 200f;
	public float currentHealth;
	public int Oins; 
	public bool isReadyToGetDamage;
	public float notGettingDamageTime;
	
	public void Awake()
	{
		
		HealthBar.maxValue = maxHealth;
		currentHealth = maxHealth;
		HealthBar.value = currentHealth;
		
	}
	
	public void GetDamage(float dmg)
	{
		
		if(isReadyToGetDamage)
		{
			
			currentHealth -= dmg;

			Debug.Log(dmg);

			HealthBar.value = currentHealth;
			
		}
		
	}
	
	void Update()
	{
		
		if(currentHealth <= 0)
		{
			
			Die();
			
		}
		
	}
	
	public void Die()
	{
		
		GameObject dieEffect = Instantiate(dieGFX, transform.position, transform.rotation);
		
		//gameoverLogo.SetActive(true);

		//gameoverLogo.GetComponent<Animator>().Play("Main Motion");
		
		Destroy(gameObject);
		
	}
	
	IEnumerator getDamageCD()
	{
		
		isReadyToGetDamage = false;
		yield return new WaitForSeconds(notGettingDamageTime);
		isReadyToGetDamage = true;
		
	}
	
}
