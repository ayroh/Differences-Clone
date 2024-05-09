using Pool;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Curves")]
public class Curves : SingletonScriptableObject<Curves>
{

    public AnimationCurve correctCheckBounceCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    public AnimationCurve foundParticleYAxisCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    public AnimationCurve wrongCheckRotationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    public AnimationCurve wrongCheckScaleCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

}
