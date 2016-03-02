﻿using UnityEngine;
using System.Collections;

public class Throwable : MonoBehaviour {

    public Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;

    public Transform Projectile;
    private Transform myTransform;   

    void Update() {
        if (Input.GetMouseButtonDown(0) && Target != null) {            
            StartCoroutine(SimulateProjectile());
        }
        // Testing purpose
        if (Input.GetMouseButtonDown(1)) {
            //Target = GameManager.gm.player.transform;
          //  StartCoroutine(SimulateProjectile());
        }

    }

    IEnumerator SimulateProjectile() {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(0.5f);

        // Move projectile to the position of throwing object + add some offset if needed.
       // Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(this.transform.position, Target.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        this.transform.rotation = Quaternion.LookRotation(Target.position - this.transform.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration) {
            this.transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }
}