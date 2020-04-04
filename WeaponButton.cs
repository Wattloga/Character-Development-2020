using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class WeaponButton : MonoBehaviour
{ 
    public WeaponConfig weaponObj;
    private Button weaponButton;
    private Image buttonImg;
    private Text buttonText;
    private void Start()
    {
        weaponButton = GetComponent<Button>();
        weaponButton.onClick.AddListener(weaponObj.RaiseFireAction);
        buttonImg = GetComponent<Image>();
        buttonImg.color = weaponObj.weaponColor;
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = weaponObj.name + "Fire";
        weaponObj.collectWeaponAction = OnCollectWeapon;
        weaponButton.interactable = false;
     }

    public void OnCollectEnter()
    {

    }
}

