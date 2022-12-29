using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoSLot[] _ammoSlots;

    [System.Serializable]
    private class AmmoSLot
    {
        public AmmoType ammoType;
        public int ammoAmount; 
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSLot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSLot(ammoType).ammoAmount--;
    }

    private AmmoSLot GetAmmoSLot(AmmoType ammoType) 
    { 
        foreach (AmmoSLot slot in _ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
