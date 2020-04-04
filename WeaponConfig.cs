using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]

public class WeaponConfig : ScriptableObject
{
    public UnityAction weaponFireAction;
    public Color weaponColor = Color.red;
    public GameObject ammoObj;
    public Color[] colorArray;
    public float firePower = 0.1f;
    public floatData playerHealth;

    public void RaiseFireAction()
    {
        weaponFireAction?.Invoke();
    }

    public Color RandomColor()
    {
        return weaponColor;
    }

    public void DoDamge()
    {
        playerHealth.UpdateValue(firePower);
    }
}
