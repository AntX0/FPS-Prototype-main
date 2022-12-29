using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoSlot[] _ammoSlots;

    [System.Serializable]
    private class AmmoSlot
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

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSLot(ammoType).ammoAmount += ammoAmount;
    }

    private AmmoSlot GetAmmoSLot(AmmoType ammoType) 
    { 
        foreach (AmmoSlot slot in _ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
