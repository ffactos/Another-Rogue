using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	
	
	public float bulletSpeed = 20f;
	public float dmg;
	public Vector2 angle;
	public Rigidbody2D rb;
	public GameObject bulletCollisionGFX;
	public Transform target;
	
	public void Awake()
	{
		
		target = GameObject.FindGameObjectWithTag("Player").transform;
		
		angle.x = target.position.x - rb.position.x;
		angle.y = target.position.y - rb.position.y;
		
		rb.velocity = angle * bulletSpeed;
		
	}
	
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		
		if(!collider.isTrigger)
		{
			
			if(collider.GetComponent<PlayerStats>() != null)
			{

				collider.GetComponent<PlayerStats>().GetDamage(dmg);

				Instantiate(bulletCollisionGFX, transform.position, transform.rotation);

				Destroy(gameObject);

			}

			else if(collider.GetComponent<Enemy>() == null)
			{

				Instantiate(bulletCollisionGFX, transform.position, transform.rotation);
				Destroy(gameObject);

			}

			else
			{

				Instantiate(bulletCollisionGFX, transform.position, transform.rotation);
				Destroy(gameObject);

			}
			
		}
		
	}
	
}
