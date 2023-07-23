using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isFiring = false;
    public ParticleSystem[] muzzleFlash;
    public ParticleSystem hitEffect;
    public TrailRenderer tracerEffect;
    public Transform raycastOrigin;
    public Transform raycastDestination;

    Ray ray;
    RaycastHit hitInfo;

    public void StartFiring(){
        isFiring = true;
        foreach(var particle in muzzleFlash){
            particle.Emit(1);
        }

        ray.origin = raycastOrigin.position;
        ray.direction = raycastDestination.position - raycastOrigin.position;

        var tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);

        if(Physics.Raycast(ray, out hitInfo)){
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 10.0f);

            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);

            tracer.transform.position = hitInfo.point;
        }
        // if (Physics.Raycast(ray, out hitInfo)) {
        // transform.position = hitInfo.point;
        // } else {
        //     transform.position = ray.origin + ray.direction * 1000.0f;
        // }
    }

    public void StopFiring(){
        isFiring = false;
    }
}
