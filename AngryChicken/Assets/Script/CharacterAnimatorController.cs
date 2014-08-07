using UnityEngine;
using System.Collections;

public class CharacterAnimatorController : MonoBehaviour {

	// ========================= ScriptD
    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<Animator>().SetTrigger("hit");
    }

}
