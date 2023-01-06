using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [Header("Movement")]
    //Movement Tiles
    [SerializeField] Tile targetTile;
    [SerializeField] Tile lastTile;

    [Header("Highlight")]
    //Tile for hover highlight
    [SerializeField] Tile tileToHighlight;

    //Colors for highlight
    [SerializeField] Color highlightColor;

    [Header("Other")]
    [SerializeField] bool playerSelected = false;
    public Player player;
    public int team = 0;

    Vector3 touchPosition;

    [SerializeField] Tile[] myTiles;

    void Update()
    {
#if UNITY_EDITOR
        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 touchPosWorld2D = new Vector2(touchPosition.x, touchPosition.y);

        RaycastHit2D hit = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
        //Hover Highlight
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.GetComponent<Tile>())
            {
                if (hit.collider.gameObject.GetComponent<Tile>().team != team) { return; }//If hovering over a tile that isn't your teams do nothing

                if (tileToHighlight != null)
                {
                    tileToHighlight.spriteRenderer.color = tileToHighlight.tileColor; 
                }

                tileToHighlight = hit.collider.gameObject.GetComponent<Tile>();
                tileToHighlight.spriteRenderer.color = highlightColor;
            }
        }

        //Movement Select
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                if (playerSelected == true)
                {
                    if (hit.collider.gameObject.GetComponent<Tile>())
                    {
                        if (hit.collider.gameObject.GetComponent<Tile>().team != team) { return; }//If hovering over a tile that isn't your teams do nothing

                        lastTile = targetTile;
                        if (lastTile != null) //Change last tile color back to normal
                        {
                            lastTile.spriteRenderer.color = lastTile.tileColor;
                        }
                        targetTile = hit.collider.gameObject.GetComponent<Tile>();
                        targetTile.spriteRenderer.color = Color.black;

                        //Create Movement Sequence
                        #region
                        if (targetTile == null) return;
                        if (player.currentTile.coordinates == targetTile.coordinates) { return; }
                        lastTile = targetTile;
                        if (lastTile != null) //Change last tile color back to normal
                        {
                            lastTile.spriteRenderer.color = lastTile.tileColor;
                        }

                        Tile playerCurrent = player.currentTile;
                        List<Tile> tileSequence = new List<Tile>();

                        Vector2Int difference = targetTile.coordinates - playerCurrent.coordinates;
                        Vector2Int temp = playerCurrent.coordinates;//temp value for forloops

                        for (int i = 0; i < Mathf.Abs(difference.x); i++)
                        {
                            if (difference.x < 0)//Left
                            {
                                for (int b = 0; b < myTiles.Length; b++)
                                {
                                    if (myTiles[b].coordinates == new Vector2Int(temp.x - 1, temp.y))
                                    {
                                        tileSequence.Add(myTiles[b]);
                                        temp.x = myTiles[b].coordinates.x;
                                        break;
                                    }
                                }
                            }
                            else//right
                            {
                                for (int b = 0; b < myTiles.Length; b++)
                                {
                                    if (myTiles[b].coordinates == new Vector2Int(temp.x + 1, temp.y))
                                    {
                                        tileSequence.Add(myTiles[b]);
                                        temp.x = myTiles[b].coordinates.x;
                                        break;
                                    }
                                }
                            }
                        }

                        for (int i = 0; i < Mathf.Abs(difference.y); i++)
                        {
                            if (difference.y < 0)//down
                            {
                                for (int b = 0; b < myTiles.Length; b++)
                                {
                                    if (myTiles[b].coordinates == new Vector2Int(temp.x, temp.y - 1))
                                    {
                                        tileSequence.Add(myTiles[b]);
                                        temp.y = myTiles[b].coordinates.y;
                                        break;
                                    }
                                }
                            }
                            else//up
                            {
                                for (int b = 0; b < myTiles.Length; b++)
                                {
                                    if (myTiles[b].coordinates == new Vector2Int(temp.x, temp.y + 1))
                                    {
                                        tileSequence.Add(myTiles[b]);
                                        temp.y = myTiles[b].coordinates.y;
                                        break;
                                    }
                                }
                            }
                        }
                        tileSequence.Add(targetTile);

                        player.CreateMoveSequence(tileSequence);
                        targetTile = null;
                        playerSelected = false;
                        #endregion
                    }
                }
                else
                {
                    if (hit.collider.gameObject.GetComponent<Player>())
                    {
                        if (player == null)
                        {
                            player = hit.collider.gameObject.GetComponent<Player>();
                        }
                        if (player.team == team)
                        {
                        playerSelected = true;
                        }
                        else
                        {
                            Debug.Log("Not Your Team");
                        }

                    }
                }
            }
        }

        //TEMP
        if (Input.GetMouseButtonDown(1))
        {
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
#endif
    }
}