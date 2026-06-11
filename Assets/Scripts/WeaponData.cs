using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject

{
    public float fireRate;
    public int damage;
    public float weaponRange;
    public Color projectileColor;
}