using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float speed;
	private Rigidbody2D rb;
	private Animator anim;
	private Vector2 moveAmount;

	public float health;
    // Start is called before the first frame update
    void Start()
    {
	anim = GetComponent<Animator>();        
	rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	moveAmount = moveInput.normalized * speed;

	if (moveInput != Vector2.zero){
		anim.SetBool("isRunning", true);	
	}
	else {
		anim.SetBool("isRunning", false);
	}
    }

    void FixedUpdate()
    {
	rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);

    }

    public void TakeDamage(int damageAmount)
    {
	health -= damageAmount;

	if(health <= 0)
	{
	   Destroy(gameObject);
	}
    }			
}
