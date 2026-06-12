using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private CoreAI coreAI;

    [SerializeField] private Button equipLaserButton;
    [SerializeField] private Button equipCanonButton;
    
    [SerializeField] private WeaponData canonData;
    [SerializeField] private WeaponData laserData;


    void Start()
    {
        equipCanonButton.onClick.AddListener(() => { EquipWeapon(canonData)});
        coreAI.currentWeapon = canonData;
    }

    void EquipWeapon(WeaponData weaponData)
    {
        coreAI.currentWeapon = weaponData;
    }

}
