using UnityEngine;
using System.Collections;

public class CrashBlock : MonoBehaviour {

//=================================== ScriptA
	/**
	 * OnCollisionEnter2D
	 * オブジェクトが衝突したときによばれる
	 */
/* 
    void OnCollisionEnter2D(Collision2D col)
    {
    	// オブジェクトを削除
        Destroy(gameObject);
    }
*/

//=================================== ScriptB
/*
    // Unity上で変更可能
    public float m_Strength = 1, m_hp = 1;
*/
   	/**
   	 * OnCollisionEnter2D
   	 * オブジェクトが衝突したときによばれる
   	 * @param col 接触するオブジェクトの情報
   	 */
/*
    void OnCollisionEnter2D(Collision2D col)
    {
        float damage = col.relativeVelocity.magnitude - m_Strength;
        if (damage > 0){
            m_hp -= damage;
        }

        if (m_hp < 0){
            Destroy(gameObject);
        }
    }
*/
//=================================== ScriptC
    public float m_Strength, m_hp;
    public GameObject m_Effect;

    void OnCollisionEnter2D(Collision2D col)
    {
        float damage = col.relativeVelocity.magnitude - m_Strength;
        if (damage > 0){
            m_hp -= damage;
        }

        if (m_hp < 0){
            Destroy(gameObject);
            Object effect = GameObject.Instantiate(
                    m_Effect, 
                    transform.position, 
                    Quaternion.identity);
            DestroyObject(effect, 1.5f);
        }
    }
}
