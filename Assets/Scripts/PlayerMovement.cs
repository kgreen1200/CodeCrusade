using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public AudioSource walkSound;

    private Rigidbody2D myRigidBody;
    private Vector3 change = Vector3.zero;
    private Animator animator;

    public static PlayerMovement Instance { get; private set; }

    // Runs before any Start() function and initializes Instance
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateAnimation();
	}

    // Updates the character movement outside of the framerate
    private void FixedUpdate() {
        MoveCharacter();
    }

    void UpdateAnimation()
    {
        if (change != Vector3.zero)
        {
            // Changes the sprite animation based on the movement of the character
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            if (!walkSound.isPlaying)
            {
                walkSound.Play(); // plays the walking audio whenever the player is moving
            }
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
        Vector3 delta = new Vector3(x, y, 0);
        delta = (delta.magnitude > 1f) ? delta.normalized : delta;
        change = delta;
    }
}
