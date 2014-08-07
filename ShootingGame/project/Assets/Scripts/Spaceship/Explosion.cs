using UnityEngine;

public class Explosion : MonoBehaviour
{
	public void Destroy ()  // 爆発アニメーションが終わった後に呼び出されるメソッド（AnimationEvent）
	{
		Destroy (gameObject);
	}
}