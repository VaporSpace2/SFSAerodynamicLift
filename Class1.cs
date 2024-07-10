using System;
using System.Collections.Generic;
using SFS;
using SFS.Builds;
using SFS.Parts.Modules;
using SFS.Translations;
using SFS.UI;
using SFS.Variables;
using SFS.World;
using UnityEngine;
using SFS.World.Drag;

public class LiftingBodyModule : MonoBehaviour, Rocket.INJ_Physics, Rocket.INJ_Rocket
{
    public Composed_Float liftArea;
    public Composed_Float liftStrength;
    public Composed_Float dragStrength;
    public Composed_Vector2 liftNormal = new Composed_Vector2(Vector2.right);
    public Composed_Vector2 liftPosition = new Composed_Vector2(Vector2.zero);

    public AnimationCurve LiftCurve = new AnimationCurve(new Keyframe(-180f, 0.0f),
        new Keyframe(-45f, -1f),
        new Keyframe(0f, 0f),
        new Keyframe(45f, 1f),
        new Keyframe(180f, 0f));

    public AnimationCurve DragCurve = new AnimationCurve(new Keyframe(-180f, 0.0f),
        new Keyframe(-45f, -1f),
        new Keyframe(0f, 0f),
        new Keyframe(45f, 1f),
        new Keyframe(180f, 0f));

    public Rigidbody2D Rb2d { get; set; }
    public Rocket Rocket { get; set; }
    public void FixedUpdate()
    {
        if (Rb2d != null)
        {
            Location location = ((PlayerController.main.player.Value != null) ? PlayerController.main.player.Value.location.Value : WorldView.main.ViewLocation);
            float AtmoDensity = (float)location.planet.GetAtmosphericDensity(location.Height);
            if (AtmoDensity <= 0f)
            {
                Vector2 velocity = Rocket.location.velocity.Value;
                float airSpeedSQRT = Mathf.Sqrt(Mathf.Abs(velocity.x) + Mathf.Abs(velocity.y));

                float angleOfAttack = Vector2.SignedAngle(transform.up, velocity);

                float liftCF = LiftCurve.Evaluate(Mathf.Abs(angleOfAttack + 180));
                float dragByAOA = DragCurve.Evaluate(Mathf.Abs(angleOfAttack + 180));

                float LiftForce = airSpeedSQRT * liftCF * liftArea.Value * liftStrength.Value * (AtmoDensity * 250f);
                float dragForce = airSpeedSQRT * dragByAOA * liftArea.Value * dragStrength.Value * (AtmoDensity * 250f);

                Vector2 vector = liftNormal.Value * LiftForce;
                Vector2 relativePoint = Rb2d.GetRelativePoint(Transform_Utility.LocalToLocalPoint(base.transform, Rb2d, liftPosition.Value));
                Vector2 force = (Base.worldBase.AllowsCheats ? ((Vector2)base.transform.TransformVector(vector)) : base.transform.TransformVectorUnscaled(vector));

                Rb2d.AddForceAtPosition(force, relativePoint, 0);
                Rb2d.AddForceAtPosition(-velocity.normalized * dragForce, relativePoint, 0);
            }
            Debug.Log("atmospheric density = " + AtmoDensity);
        }
    }
}
