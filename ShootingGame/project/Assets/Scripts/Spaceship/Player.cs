using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	Spaceship spaceship;
	
	void Awake ()
	{
		spaceship = GetComponent<Spaceship> ();
	}

	void Update ()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		
		spaceship.Move (new Vector2 (x, y).normalized);
		
		Clamp ();   // 移動制限
	}
	
	void Clamp ()
	{
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp (pos.x, -4, 4); //X軸は-4~4まで移動できる
		pos.y = Mathf.Clamp (pos.y, -3, 3); //Y軸は-3~3まで移動できる
		transform.position = pos;
	}

	IEnumerator Start ()
	{
		while (true) {
			spaceship.Shot (transform);
			yield return new WaitForSeconds (spaceship.shotDelay);  // shotDelay秒待つ
		}
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		spaceship.Explode ();
	}
}