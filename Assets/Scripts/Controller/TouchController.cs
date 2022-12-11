using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] Tile currentTile;
    [SerializeField] Tile lastTile;

    Vector3 touchPosition;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 touchPosWorld2D = new Vector2(touchPosition.x, touchPosition.y);

            RaycastHit2D hit = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<Tile>())
                {
                    lastTile = currentTile;
                    if (lastTile != null) //Change last tile color back to normal
                    {
                        lastTile.spriteRenderer.color = Color.white;
                    }
                    currentTile = hit.collider.gameObject.GetComponent<Tile>();
                    currentTile.spriteRenderer.color = Color.grey;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastTile = currentTile;
            if (lastTile != null) //Change last tile color back to normal
            {
                lastTile.spriteRenderer.color = Color.white;
            }
            currentTile = null;
        }
#endif
    }
}