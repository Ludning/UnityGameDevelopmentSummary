using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strategy : MonoBehaviour
{

}


public interface IWeapon
{
    public void Shoot();
}
public class Rifle : IWeapon
{
    public void Shoot()
    {
        Debug.Log("라이플 발사");
    }
}
public class Revolver : IWeapon
{
    public void Shoot()
    {
        Debug.Log("리볼버 발사");
    }
}

public class Weapon
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
public class PrimaryWeapon : Weapon
{

}
public class SecondaryWeapon : Weapon
{

}
public class PowerWeapon : Weapon
{

}

public class Player
{
    PrimaryWeapon primaryWeapon = new PrimaryWeapon();
    SecondaryWeapon secondaryWeapon = new SecondaryWeapon();
    PowerWeapon powerWeapon = new PowerWeapon();

    Weapon currentWeapon;

    public void Init()
    {
        SwapWeapon(primaryWeapon);
    }
    public void Shoot()
    {
        currentWeapon.Shoot();
    }
    public void SwapWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
    }
    public void SetPrimaryWeapon()
    {
        primaryWeapon.SetWeapon(new Revolver());
    }
}

