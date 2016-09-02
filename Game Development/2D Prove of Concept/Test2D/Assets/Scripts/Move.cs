using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private Vector3 mousePosition;
	private Rigidbody2D rb2d;
	private Vector3 destiny;
	private bool onTravel;
	private bool facingRight;
	private Animator animator;

	public float maxSpeed = 5f;

	// Use this for initialization
	void Start () {
		mousePosition = new Vector3 ();
		rb2d = GetComponent<Rigidbody2D> ();
		destiny = new Vector3 ();
		onTravel = false;
		facingRight = true;
		animator = this.GetComponent<Animator>();
		animator.SetInteger("State_body",0);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			mousePosition = Input.mousePosition;
			Vector3 newPos = new Vector3 (ConverteWidth(mousePosition.x), transform.position.y, 0);
			destiny = newPos;
			onTravel = true;
			if (facingRight) {
				if (destiny.x < transform.position.x)
					Flip ();
			} else {
				if (destiny.x > transform.position.x)
					Flip ();
			}
		}
		if (onTravel) {
			transform.Translate (new Vector3 (Time.deltaTime * maxSpeed , 0, 0));
			if (Mathf.Abs (destiny.x - transform.position.x) < 0.05f)
				onTravel = false;
			animator.SetInteger("State_body",1);
		}else{
			animator.SetInteger("State_body",0);
		}
	}

	float ConverteWidth(float coordScreen){
		return mousePosition.x*20/Screen.width-10;
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
