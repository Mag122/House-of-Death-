using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public LayerMask layerMask;
    public float distance;
    public Camera _camera;
    public GameObject ManageController;
    private ResourseManager RM;

    void Start()
    {
        RM = FindObjectOfType<ResourseManager>();
    }

    public void Shoot()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = _camera.ScreenPointToRay(screenCenter);

        Debug.DrawRay(screenCenter, new Vector3(Screen.width / 2, Screen.height / 2, distance), Color.red);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, layerMask) && RM.Ammo > 0)
        {
            RM.UseAmmo();
            if (hitInfo.collider.gameObject.tag == "Enemy")
            {
                hitInfo.collider.gameObject.GetComponent<EnemyBehaviour>().LossHP(RM.WeaponDamage);
            }
            Debug.Log("hit");
        }
    }
}
