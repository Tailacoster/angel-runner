using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float wingFlapUpForce = 5f;
    [SerializeField] float wingFlapCooldown = 0.5f;

    Rigidbody2D rigidBody;

    bool canFlap = true;

	void Start()
	{
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{
        //if (VelocityBelowZero())
        //{
        //    rigidBody.gravityScale = 1.5f;
        //}
        //else
        //{
        //    rigidBody.gravityScale = 1;
        //}

		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            if (canFlap)
            {
                StartCoroutine(FlapWings());
            }
        }
	}

    // Causes the player to flap their wings. Core movement mechanic 1 of 3.
    private IEnumerator FlapWings()
    {
        canFlap = false;
        rigidBody.velocity = Vector2.zero;
        rigidBody.AddForce(new Vector2(0f, wingFlapUpForce));
        yield return new WaitForSeconds(wingFlapCooldown);
        canFlap = true;
    }

    // returns true if velocity is below zero
    private bool VelocityBelowZero()
    {
        if (rigidBody.velocity.y < 0)
        {
            return true;
        }

        return false;
    }
}