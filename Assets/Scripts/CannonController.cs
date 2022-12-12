using UnityEngine;

public class CannonController : MonoBehaviour
{
    public bool CanFire { get; set; }
    
    public void AimCannon()
    {
        // darken player's ship deck UI
        // switch cursor to aim mode
        // determine a random damage shape
        
    }

    public void FireCannon()
    {
        if (CanFire)
        {
            // unload cannon ball from inventory?
            // call event for cannonball fired at x,y location
            // disable aiming mode
        }
        else
        {
            // Show that the user cannot fire under current conditions
        }
    }
}
