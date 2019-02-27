using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimationController : AnimationSpeedController {


    public void AnimationEnd()
    {
        Destroy(gameObject);
    }
}
