using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	
	
	public float speed = 1f;
	public float jumpForce = 5f;
	public float jumpRadius = 0.5f;
	public float hInput;
	
	public bool isGrounded;
	public bool isFacingRight = true;
	
	public Rigidbody2D rb;
	public Transform feetPos;
	
	void Start()
	{
		
		rb = GetComponent<Rigidbody2D>();
		
	}

	
	void Update()
	{
		
		hInput = Input.GetAxis("Horizontal");
		
		if(Math.Abs(hInput) > 0.3f || Math.Abs(rb.velocity.y) > 0f)
			rb.velocity = new Vector2(hInput * speed, rb.velocity.y);
		else
			rb.velocity = Vector2.zero;
			
		isGrounded = Physics2D.OverlapCircle(feetPos.position, jumpRadius).CompareTag("Ground");		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			
			if(isGrounded)
			{
				
				rb.AddForce(new Vector2(0f, jumpForce));
					
			}
			
		}
		
		if(rb.velocity.x < 0 && isFacingRight)
			Flip();
		else if(rb.velocity.x > 0 && !isFacingRight)
			Flip();
		
	}
	
	public void Flip()
	{
		
		Vector2 vector = transform.localScale;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		isFacingRight = !isFacingRight;
		
	}
	
	private void OnDrawGizmosSelected()
	{
		
		Gizmos.DrawWireSphere(feetPos.position, jumpRadius);
		
	}
	
	
	
}
