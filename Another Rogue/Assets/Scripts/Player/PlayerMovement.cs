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
			
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(isGrounded)
				rb.AddForce(new Vector2(0f, jumpForce));
			
		}
		
		for (int i = 0; i < Physics2D.OverlapCircleAll(feetPos.position, jumpRadius).Length; i++)
			isGrounded = Physics2D.OverlapCircleAll(feetPos.position, jumpRadius)[i].CompareTag("Ground");
		
	}
	
	//public void Flip()
	//{
	//	
	//	Vector2
	//	
	//}
	
	private void OnDrawGizmosSelected()
	{
		
		Gizmos.DrawWireSphere(feetPos.position, jumpRadius);
		
	}
	
	
	
}
