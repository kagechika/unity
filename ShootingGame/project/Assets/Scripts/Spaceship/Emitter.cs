using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour
{
	public GameObject[] waves;
	private int currentWave;
	
	IEnumerator Start ()
	{
		
		if (waves.Length == 0) {
			yield break;
		}
		
		while (true) {
			
			GameObject g = (GameObject)Instantiate (waves [currentWave], transform.position, Quaternion.identity);
			
			g.transform.parent = transform;             // WaveをEmitterの子要素にする
			
			while (g.transform.childCount != 0) {       // Waveの敵がいなくなるまで待機
				yield return new WaitForEndOfFrame ();
			}
			
			Destroy (g);
			
			if (waves.Length <= ++currentWave) {    // 全てのWaveが終わったら最初に戻る（ループ）
				currentWave = 0;
			}
			
		}
	}
}