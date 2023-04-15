using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourseManager : MonoBehaviour
{
    public float EnemyHP;
    public float EnemyDamage;
    public float Ammo;
    public float PlayerHP;
    public float WeaponDamage;
    public TMP_Text AmmoCount, HPCount, Win;
    public GameObject zombies;

    public void Start()
    {
        AmmoCount.text = Ammo.ToString();
        HPCount.text = PlayerHP.ToString();
    }

    public void Update()
    {
        if (zombies.transform.childCount == 0)
        {
            Win.enabled = true;
            StartCoroutine(FindObjectOfType<Move>().Restart());
        }
    }

    public void UpdateHP(float HP)
    {
        HPCount.text = HP.ToString();
    }


    public void UseAmmo()
    {
        Ammo -= 1;
        AmmoCount.text = Ammo.ToString();
    }

    public void PlusAmmo()
    {
        Ammo += 5;
        AmmoCount.text = Ammo.ToString();
    }
}
