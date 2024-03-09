using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    [SerializeField] int num = 0;
    [SerializeField] Transform guns;
    [SerializeField] Transform cH;
    // Start is called before the first frame update
    void Start()
    {
        GunSelection();
        CrosshairSelection();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            num = 0;
            GunSelection();
            CrosshairSelection();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            num = 1;
            GunSelection();
            CrosshairSelection();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            num = 2;
            GunSelection();
            CrosshairSelection();
        }
    }

    private void GunSelection()
    {
        int i = 0;
        foreach(Transform weapon in guns) 
        {
            if (i == num)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    private void CrosshairSelection()
    {
        int i = 0;
        foreach(Transform crosshair in cH)
        {
            if (i == num)
                crosshair.gameObject.SetActive(true);
            else
                crosshair.gameObject.SetActive(false);
            i++;
        }
    }

}
