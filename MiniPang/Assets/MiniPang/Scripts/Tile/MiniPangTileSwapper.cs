using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPangTileSwapper
{
    private MiniPangBoardManager boardManager;

    public MiniPangTileSwapper(MiniPangBoardManager manager)
    {
        boardManager = manager;
    }

    public void SwapTiles(MiniPangTile tile1, MiniPangTile tile2)
    {
        int tempX = tile1.x;
        int tempY = tile1.y;

        tile1.MoveTo(tile2.x, tile2.y);
        tile2.MoveTo(tempX, tempY);

        boardManager.board[tile1.x, tile1.y] = tile1;
        boardManager.board[tile2.x, tile2.y] = tile2;
    }

    public IEnumerator TrySwapAndMatch(MiniPangTile tile1, MiniPangTile tile2)
    {
        boardManager.DisableAllTileColliders();

        SwapTiles(tile1, tile2);

        yield return new WaitForSeconds(0.3f);

        List<MiniPangTile> match1Horizontal = MiniPangMatchUtility.FindHorizontalMatch(boardManager, tile1);
        List<MiniPangTile> match1Vertical = MiniPangMatchUtility.FindVerticalMatch(boardManager, tile1);
        List<MiniPangTile> match2Horizontal = MiniPangMatchUtility.FindHorizontalMatch(boardManager, tile2);
        List<MiniPangTile> match2Vertical = MiniPangMatchUtility.FindVerticalMatch(boardManager, tile2);

        HashSet<MiniPangTile> uniqueMatches = new HashSet<MiniPangTile>();
        uniqueMatches.UnionWith(match1Horizontal);
        uniqueMatches.UnionWith(match1Vertical);
        uniqueMatches.UnionWith(match2Horizontal);
        uniqueMatches.UnionWith(match2Vertical);

        if (uniqueMatches.Count >= 3)
        {
            yield return new WaitForSeconds(0.3f);
            yield return boardManager.tileDestroyer.DestroyAllMatchedTiles(new List<MiniPangTile>(uniqueMatches));
        }
        else
        {
            SwapTiles(tile1, tile2);
            yield return new WaitForSeconds(0.3f);
        }

        boardManager.EnableAllTileColliders();
        yield return boardManager.tileChecker.CheckPossibleSwaps();
    }
}
