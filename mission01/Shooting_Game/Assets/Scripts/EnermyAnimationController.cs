using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyAnimationController : MonoBehaviour {

    Animation anim;
    ArrayList state;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        foreach (AnimationState state in anim)
        {
            Debug.Log(state.name);
        }
        anim.Play();
    }

    void Update () {
        bool canWalk = Input.GetKeyDown(KeyCode.W);
        bool canRun = Input.GetKeyDown(KeyCode.R);
        bool canJump = Input.GetKeyDown(KeyCode.J);
        bool canAttack = Input.GetKeyDown(KeyCode.A);
        if (canWalk) { anim.Play(); }
        if (canRun) { anim.Play("Allosaurus_Run"); }
        if (canJump) { anim.Play("Allosaurus_Jump"); }
        if (canAttack) { anim.Play("Allosaurus_Attack01"); }
    }

}
