using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
	public int hp;

	public float speed;
	
	public void Move (Vector2 direction)
	{
		rigidbody2D.velocity = direction * speed;   // 速度と向きを設定する
	}

	public GameObject bullet;
	public float shotDelay;
	public bool canShot;
	
	public void Shot (Transform origin)
	{
		Instantiate (bullet, origin.position, origin.rotation); // プレイヤーの位置に弾を作成する
	}

	public GameObject explosion;
	
	public void Explode ()
	{
		GameObject go = (GameObject)Instantiate (explosion, transform.position, transform.rotation);
		go.transform.localScale = transform.localScale; // 爆発の大きさを機体と同じ大きさにする
		Destroy (gameObject);
	}
}