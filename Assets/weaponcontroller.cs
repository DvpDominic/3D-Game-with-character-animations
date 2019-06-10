using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponcontroller : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            switchWeapons();
        }

    }

    void switchWeapons()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(!weapon.gameObject.activeSelf);
        }
    }

}
