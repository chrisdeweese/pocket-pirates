using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TouchController : MonoBehaviour
{
    [SerializeField] Tile targetTile;
    [SerializeField] Tile lastTile;

    [SerializeField] bool playerSelected = false;
    Player player;

    Vector3 touchPosition;

    private Tile[] allTiles;

    private void Awake()
    {
        player = FindObjectOfType<Player>();

        allTiles = FindObjectsOfType<Tile>() ?? new Tile[25];
    }

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
                if (playerSelected == true)
                {
                    if (hit.collider.gameObject.GetComponent<Tile>())
                    {
                        lastTile = targetTile;
                        if (lastTile != null) //Change last tile color back to normal
                        {
                            lastTile.spriteRenderer.color = Color.white;
                        }
                        targetTile = hit.collider.gameObject.GetComponent<Tile>();
                        targetTile.spriteRenderer.color = Color.grey;
                    }
                }
                else
                {
                    if (hit.collider.gameObject.GetComponent<Player>())
                    {
                        playerSelected = true;
                    }
                }
            }
        }

        //TEMP
        if (Input.GetMouseButtonDown(1))
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 touchPosWorld2D = new Vector2(touchPosition.x, touchPosition.y);

            RaycastHit2D hit = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<Tile>())
                {
                    Tile tempTile = hit.collider.gameObject.GetComponent<Tile>();
                    tempTile.ToggleBreak(!tempTile.isBroken);
                }
            }
        }
                //END TEMP
        if (Input.GetMouseButtonUp(0))
        {
            if (playerSelected == true)
            {
                if (targetTile == null) return;
                if (player.currentTile.coordinates == targetTile.coordinates) { return; }
                lastTile = targetTile;
                if (lastTile != null) //Change last tile color back to normal
                {
                    lastTile.spriteRenderer.color = Color.white;
                }

                Vector2Int playerCurrent = player.currentTile.coordinates;
                List<Vector2Int> targetPositions = new List<Vector2Int>();
                targetPositions.Add(playerCurrent);
                for (int x = 1; x < 5; x++)
                {
                    if (targetTile.coordinates.x < targetPositions.Last<Vector2Int>().x)
                    {
                        Vector2Int nextTile = new Vector2Int(x - 1, playerCurrent.y);
                        targetPositions.Add(nextTile);
                    }
                    else if (targetTile.coordinates.x > targetPositions.Last<Vector2Int>().x)
                    {
                        Vector2Int nextTile = new Vector2Int(x + 1, playerCurrent.y);
                        targetPositions.Add(nextTile);
                    }
                    else
                    {
                        break;
                    }
                }
                for (int y = 1; y < 5; y++)
                {
                    if (targetTile.coordinates.y < targetPositions.Last<Vector2Int>().y)
                    {
                        Vector2Int nextTile = new Vector2Int(targetTile.coordinates.x, targetPositions.Last<Vector2Int>().y - 1);
                        targetPositions.Add(nextTile);
                    }
                    else if (targetTile.coordinates.y > targetPositions.Last<Vector2Int>().y)
                    {
                        Vector2Int nextTile = new Vector2Int(targetTile.coordinates.x, targetPositions.Last<Vector2Int>().y + 1);
                        targetPositions.Add(nextTile);
                    }
                    else
                    {
                        break;
                    }
                }
                List<Tile> tileSequence = new List<Tile>();
                foreach (var item in targetPositions)
                {
                    for (int i = 0; i < allTiles.Length; i++)
                    {
                        if (allTiles[i].coordinates == item)
                        {
                            tileSequence.Add(allTiles[i]);
                        }
                    }
                }

                player.CreateMoveSequence(tileSequence);
                targetTile = null;
                playerSelected = false;
            }
        }
#endif
    }
}