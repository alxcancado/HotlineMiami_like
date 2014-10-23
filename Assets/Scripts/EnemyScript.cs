using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed;
	public Transform player;

	void FixedUpdate(){
		float z = Mathf.Atan2 ((player.transform.position.y - this.transform.position.y),
		                      (player.transform.position.x - this.transform.position.x)) *
						Mathf.Rad2Deg - 90;

		transform.eulerAngles = new Vector3 (0, 0, z);
		rigidbody2D.AddForce (gameObject.transform.up * speed);
	}
}
