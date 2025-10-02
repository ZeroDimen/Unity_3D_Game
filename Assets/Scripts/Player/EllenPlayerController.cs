using System;
using UnityEngine;

public class EllenPlayerController : PlayerController
{
    [SerializeField] private Transform weaponAttachTransform;
    private void Start()
    {
        // 무기 할당
        var staffObject = Resources.Load<GameObject>("Weapon/Staff");
        Instantiate(staffObject, weaponAttachTransform);
    }

    public void MeleeAttackStart()
    {
        
    }

    public void MeleeAttackEnd()
    {
        
    }
}