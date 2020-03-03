using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change = Vector3.zero;
    private Animator animator;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateAnimation();
	}

    private void FixedUpdate() {
        MoveCharacter();
    }

    void UpdateAnimation()
    {
        if (change != Vector3.zero)
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    public void SetChange(int x, int y)
    {
        Vector2 delta = new Vector2(x, y);
        delta = (delta.magnitude > 1f) ? delta.normalized : delta;
        change.x = delta.x;
        change.y = delta.y;
    }
}
