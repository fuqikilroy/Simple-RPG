using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon weapon;
    public Sprite weaponIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon!=null && Input.GetKeyDown(KeyCode.Space))
        {
            weapon.Attack();
        }
    }

    public void LoadWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }
    public void LoadWeapon(ItemSO itemSO)
    {
        if (weapon != null)
        {
            Destroy(weapon.gameObject);
            weapon = null;
        }

        string prefabName = itemSO.prefab.name;
        Transform weaponParent = transform.Find(prefabName + "Position");
        GameObject weaponGo = GameObject.Instantiate(itemSO.prefab);
        weaponGo.transform.parent = weaponParent;
        weaponGo.transform.localPosition = Vector3.zero;
        weaponGo.transform.localRotation = Quaternion.identity;

        this.weapon = weaponGo.GetComponent<Weapon>();
        this.weaponIcon = itemSO.icon;
        PlayerPropertyUI.Instance.UpdatePlayerPropertyUI();
    }
    public void UnloadWeapon()
    {
        weapon = null;
    }

}
