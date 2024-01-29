using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RangeDefaultAttack : MonoBehaviour
{
	
	public SpriteRenderer spriteRenderer;
	public Slider ammoSlider;
	public Transform firePoint;
	public Vector2 mousePos;
	public Text ammoAmount;
	public Rigidbody2D rb;
	public Animator anim;
	public Camera cam;
	public GameObject bulletPrefab;
	public GameObject weaponHolder;
	public float reloadTime;
	public float CD = 10f;
	public float offset;
	public float angle;
	public float dmg;
	public bool isReadyToShoot = true;
	public bool isFacingRight;
	public bool isAnimating = false;
	public int bullets;
	public int currentBullets;
	
	void Awake()
	{
		
		weaponHolder = GameObject.FindGameObjectWithTag("Weapon Holder");	
		cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		ammoAmount = GameObject.FindGameObjectWithTag("Ammo Amount").GetComponent<Text>();		
		ammoAmount.text = "0/0";
		ammoSlider = GameObject.FindGameObjectWithTag("Ammo Slider").GetComponent<Slider>();
		
		ammoSlider.maxValue = bullets;
		currentBullets = bullets;
		ammoSlider.value = currentBullets;
		
	}
	
	void Update()
	{
		
		isFacingRight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().isFacingRight;
		if(Input.GetKey(KeyCode.Mouse0) && isReadyToShoot)
		{
		
			Shoot();
			
		}
		
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		
	}
	
	void FixedUpdate()
	{
		
		if(!isAnimating)
		{
			Vector2 lookDir = mousePos - rb.position;
			angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - offset;
			rb.rotation = angle;
			transform.position = weaponHolder.transform.position;
		}
		
		if(angle > 90f || angle < -90f)
		{
			spriteRenderer.flipY = true;
		}
		else
		{
			spriteRenderer.flipY = false;
		}
		if(!isFacingRight)
		{
			Vector3 vector = transform.localScale;
			vector.x = -1;
			transform.localScale = vector;
		}
		else
		{
			Vector3 vector = transform.localScale;
			vector.x = 1;
			transform.localScale = vector;
		}
		
		
		
	}
	
	void Shoot()
	{
		
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		bullet.GetComponent<Bullet>().dmg = dmg;
		StartCoroutine(shootCD(CD));
		
	}
	
	IEnumerator shootCD(float cd)
	{
		if(currentBullets != 0)
		{
			
			isReadyToShoot = false;
			currentBullets--;
			ammoAmount.text = currentBullets.ToString() + "/" + bullets.ToString();
			ammoSlider.value = currentBullets;
			anim.SetBool("IsShooting", true);
			yield return new WaitForSecondsRealtime(cd);
			anim.SetBool("IsShooting", false);
			isReadyToShoot = true;
			
		}
		else
		{
			isReadyToShoot = false;
			anim.SetBool("IsReloading", true);
			yield return new WaitForSecondsRealtime(reloadTime);
			ammoSlider.value = currentBullets;
			anim.SetBool("IsReloading", false);
			isReadyToShoot = true;
			currentBullets = bullets;
			ammoAmount.text = currentBullets.ToString() + "/" + bullets.ToString();
		}
		
		
	}
	
}
