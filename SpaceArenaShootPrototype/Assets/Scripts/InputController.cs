using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(MouseAim))]
[RequireComponent(typeof(PlayerWeapon))]
public class InputController : MonoBehaviour
{
    private MouseAim ma;
    private PlayerMovement pm;
    private PlayerWeapon pw;

    private void Start()
    {
        pw = GetComponent<PlayerWeapon>();
        ma = GetComponent<MouseAim>();
        pm = GetComponent<PlayerMovement>();
    }

    //tem que ser update porque mexe com a física do player
    void FixedUpdate()
    {
        var vertical = Input.GetAxisRaw("Vertical");
        if (vertical > 0)
            pm.Accelerate();
        else if (vertical < 0)
            pm.Reverse();

        var horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal < 0)
            pm.StrafeToLeft();
        else if (horizontal > 0)
            pm.StrafeToRight();

        var roll = Input.GetAxis("Roll");
        if (roll > 0)
        {
            ma.RollRight();
        }
        else if(roll < 0)
        {
            ma.RollLeft();
        }

        var fire = Input.GetAxisRaw("Fire");
        if (fire > 0)
            pw.Shoot();
    }
}
