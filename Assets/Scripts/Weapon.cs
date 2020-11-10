using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public ParticleSystem tracer;
    public GameObject impactEffect;
    public AudioSource gunShot;
    public float damage = 20f;
    void Start() {
        gunShot = GetComponent<AudioSource>();
    }
    void Update () {
        if(Input.GetButtonDown("Fire1")) {
            FireWeapon();
        }
    }
    void FireWeapon() {
        muzzleFlash.Play();
        tracer.Play();
        gunShot.Play(0);
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Hit: " + hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null) {
                target.TakeDamage(damage);
            }
            // Spawn impact effects 
            GameObject impactGameObj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            // Destroy bullet game object
            Destroy(impactGameObj, .8f);
        }
        else {
            Debug.Log("Miss. Git gud scrub");
        }
    }
}