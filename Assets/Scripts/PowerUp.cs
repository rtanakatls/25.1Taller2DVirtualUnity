using UnityEngine;

public enum PowerUpType
{
    Pistol,
    MachineGun
    
}

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType type;

    public PowerUpType Type {  get { return type; } }
}
