using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DieCD : MonoBehaviour
{
	
	public float cd = 0.5f;
	
	public void Awake()
	{
		
		Destroy(gameObject, cd);
		
	}
	
}
