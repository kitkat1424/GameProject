 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterAiming : MonoBehaviour
{
    public float turnSpeed = 15f;
    public float aimDuration = 0.3f;
    public Rig aimLayer;

    Camera mainCamera;
    RaycastWeapon weapon;
    
    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        weapon = GetComponentInChildren<RaycastWeapon>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y; 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }

    private void Update(){
        if(aimLayer){
        if(Input.GetButton("Fire2")){
            aimLayer.weight += Time.deltaTime / aimDuration;
        }else{
            aimLayer.weight -= Time.deltaTime / aimDuration;
        }
        }
        if(Input.GetButtonDown("Fire1")){
            weapon.StartFiring();
        }
        if(Input.GetButtonUp("Fire1")){
            weapon.StopFiring();
        }
    }
}
