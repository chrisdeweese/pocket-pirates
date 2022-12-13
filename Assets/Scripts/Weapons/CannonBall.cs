using UnityEngine;

[CreateAssetMenu(menuName = "Items/CannonBall")]
public class CannonBall : ItemBase
{
    public Vector2 Location { get; set; }

    public CannonBall(Vector2 newLocation)
    {
        Location = newLocation;
    }
}


