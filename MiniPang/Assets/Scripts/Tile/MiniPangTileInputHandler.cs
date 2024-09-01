using UnityEngine;

public class MiniPangTileInputHandler
{
    private MiniPangTile tile;
    private MiniPangBoardManager boardManager;

    public MiniPangTileInputHandler(MiniPangTile _tile, MiniPangBoardManager _boardManager)
    {
        tile = _tile;
        boardManager = _boardManager;
    }

    public void HandleInput(ref MiniPangTile selectedTile)
    {
        if (selectedTile == null)
        {
            selectedTile = tile;
        }
        else if (selectedTile == tile)
        {
            selectedTile = null;
        }
        else
        {
            if (!IsAdjacentTo(selectedTile))
            {
                selectedTile = null;
            }
            else
            {
                boardManager.StartCoroutine(boardManager.tileSwapper.TrySwapAndMatch(selectedTile, tile));
                selectedTile = null;
            }
        }
    }

    private bool IsAdjacentTo(MiniPangTile otherTile)
    {
        return (Mathf.Abs(tile.x - otherTile.x) == 1 && tile.y == otherTile.y) ||
               (Mathf.Abs(tile.y - otherTile.y) == 1 && tile.x == otherTile.x);
    }
}
