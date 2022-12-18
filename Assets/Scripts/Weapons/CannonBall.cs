using UnityEngine;

[CreateAssetMenu(menuName = "Items/CannonBall")]
public class CannonBall : MonoBehaviour
{
    public Vector2 Location { get; set; }

    public CannonBall(Vector2 newLocation)
    {
        Location = newLocation;
    }
}


