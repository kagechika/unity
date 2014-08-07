using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	private Animator animator;
	private Spaceship spaceship;
	
	void Awake ()
	{
		spaceship = GetComponent<Spaceship> ();
		animator = GetComponent<Animator> ();
	}

	void Start ()
	{
		spaceship.Move (transform.up * -1);
		
		if (spaceship.canShot) {        // <- これをここの位置にコピペ
			StartCoroutine (Shot ());   // <- これをここの位置にコピペ
		}                               // <- これをここの位置にコピペ
	}
	
	IEnumerator Shot ()
	{
		Transform[] shotPositions = GetComponentsInChildren<Transform> ();
		
		while (true) {
			
			foreach (Transform shotPosition in shotPositions) {
				
				if (transform == shotPosition)  // 取得したTransformに自分自身も含まれてしまっているのでここでチェックして省く
					continue;
				
				spaceship.Shot (shotPosition);
			}
			
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		int layer = LayerMask.NameToLayer ("PlayerBullet"); 
		if (c.gameObject.layer == layer) {  // レイヤー名が「PlayerBullet」のゲームオブジェクトのみダメージを受ける
			Destroy (c.gameObject);         // 弾を削除
			OnDamage ();
		}
	}
	
	void OnDamage ()
	{
		animator.SetTrigger ("Damage");     // AnimatorへDamageトリガーをセット
		
		if (--spaceship.hp <= 0) {          // HPが0になったら爆発
			spaceship.Explode ();
		}           
	}
}