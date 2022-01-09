using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleWeaponEquipment : MonoBehaviour
{
    [SerializeField]
    Image imageWeapon;
    [SerializeField]
    Image imageSelectedWeapon;
    [SerializeField]
    Toggle TgSelected;

    [SerializeField]
    List<Detail> detail= new List<Detail>();
    [SerializeField]
    List<Detail> update = new List<Detail>();
    [SerializeField]
    Text damage, dispersion, rateOfFire, reloadSpeed, anumminition, btnBNB, btnEWAR;


    bool isBounded;
    bool isUsed;
    //[SerializeField]
    //List<Detail> listDetail = new List<Detail>();

    // Start is called before the first frame update
    private void Awake()
    {
        if (TgSelected.isOn)
        {
            useToggle();
        }
        
    }
    void Start()
    {
        //listDetail.Add()
    }

    private void Update()
    {
        
    }
    public void useToggle()
    {
        Debug.Log("using toggle in " + Time.time);
        imageWeapon.sprite = imageSelectedWeapon.sprite;
        damage.text = detail[0].value+"";
        dispersion.text = detail[1].value + "";
        rateOfFire.text = detail[2].value + " RPM";
        reloadSpeed.text = detail[3].value + "%";
        anumminition.text = detail[4].value + "/100";
        btnBNB.text = update[0].value + " BNB";
        btnEWAR.text = update[1].value + " EWAR";
    }
}

[Serializable]
public struct Detail
{
    public string detail;
    public int value;
}
