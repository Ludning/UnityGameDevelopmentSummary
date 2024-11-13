using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    IWeapon weapon;
    public void Shoot()
    {
        weapon.Shoot();
    }
    public void SetWeapon(IWeapon weapon)
    {
        this.weapon = weapon;
    }
}
