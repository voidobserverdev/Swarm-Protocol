using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Button swapWeaponButton;
    [SerializeField] private CoreAI coreAI;
    [SerializeField] private WeaponData canonData;
    [SerializeField] private WeaponData laserData;


    void Start()
    {
        swapWeaponButton.onClick.AddListener(() =>
        {
            SwapWeapon();
        });
        coreAI.currentWeapon = canonData;
    }

    void SwapWeapon()
    {
        if (coreAI.currentWeapon == canonData)
        {
            coreAI.currentWeapon = laserData;
        }
        else
        {
            coreAI.currentWeapon = canonData;
        }
    }

}
