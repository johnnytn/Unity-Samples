using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Prerequisite))]
public class Receiver : Switcher {

    public Transform target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;

    private Transform projectile;
    private Vector3 playerPosition;

    public override void Interact() {
         base.Interact();

        if (Input.GetMouseButtonDown(0) && target != null) {
            Vector3 playerPosition = GameManager.gm.player.transform.position;
            projectile = Instantiate(pre.itemController.transform, playerPosition, Quaternion.identity) as Transform;
            StartCoroutine(ThrowProjectile());
        }

    }


    IEnumerator ThrowProjectile() {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(0.1f);

        // Move projectile to the position of throwing object + add some offset if needed.
        //projectile.position = playerPosition + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(projectile.position, target.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target
        projectile.rotation = Quaternion.LookRotation(target.position - projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration) {
            projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }
}