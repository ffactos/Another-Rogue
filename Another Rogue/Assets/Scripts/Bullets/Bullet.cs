using System.Collections;
using System.Collections.Generic; 
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	
	public bool isFacingRight;
	public float bulletSpeed = 20f;
	public float dmg;
	public float angle;
	public Rigidbody2D rb;
	public GameObject bulletCollisionGFX;
	Quaternion GFXrotate;
	
	void Awake()
	{
		
		isFacingRight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().isFacingRight;
		angle = GameObject.FindGameObjectWithTag("Weapon Holder").GetComponentInChildren<RangeDefaultAttack>().angle;
		rb.rotation = angle;
		
		if(isFacingRight)
		{
			rb.velocity = transform.up * bulletSpeed;
			Quaternion GFXrotate = new Quaternion(angle, transform.rotation.y, transform.rotation.z, transform.rotation.w );
		}
		
		else
		{
			rb.velocity = transform.up * bulletSpeed;
			Quaternion GFXrotate = new Quaternion(-angle, transform.rotation.y, transform.rotation.z, transform.rotation.w );
		}
		
	}
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		
		if(!collider.isTrigger)
		{
			
			if(collider.GetComponent<Enemy>() != null)
			{

				collider.GetComponent<Enemy>().GetDamage(dmg);

				Instantiate(bulletCollisionGFX, transform.position, GFXrotate);

				Destroy(gameObject);

			}

			else if(collider.GetComponent<PlayerMovement>() == null)
			{

				Instantiate(bulletCollisionGFX, transform.position, GFXrotate);
				Destroy(gameObject);

			}

			else
			{

				Instantiate(bulletCollisionGFX, transform.position, GFXrotate);
				Destroy(gameObject);

			}
			
		}
		
	}
	
}
