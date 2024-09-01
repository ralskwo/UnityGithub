using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPangMatchChecker
{
    private MiniPangBoardManager boardManager;

    public MiniPangMatchChecker(MiniPangBoardManager manager)
    {
        boardManager = manager;
    }

    public IEnumerator CheckForMatches()
    {
        List<MiniPangTile> allMatchedTiles = new List<MiniPangTile>();

        for (int y = 0; y < boardManager.boardSize; y++)
        {
            for (int x = 0; x < boardManager.boardSize; x++)
            {
                if (boardManager.board[x, y] != null)
                {
                    List<MiniPangTile> match = FindMatch(boardManager.board[x, y]);
                    if (match.Count >= 3)
                    {
                        allMatchedTiles.AddRange(match);
                    }
                }
            }
        }

        if (allMatchedTiles.Count > 0)
        {
            yield return boardManager.tileDestroyer.DestroyAllMatchedTiles(allMatchedTiles);
            yield return new WaitForSeconds(0.5f);
            yield return boardManager.boardUpdater.UpdateBoard();
        }
        else
        {
            yield return boardManager.tileChecker.CheckPossibleSwaps();
        }
    }

    public List<MiniPangTile> FindMatch(MiniPangTile tile)
    {
        List<MiniPangTile> horizontalMatch = MiniPangMatchUtility.FindHorizontalMatch(boardManager, tile);
        List<MiniPangTile> verticalMatch = MiniPangMatchUtility.FindVerticalMatch(boardManager, tile);

        HashSet<MiniPangTile> allMatches = new HashSet<MiniPangTile>(horizontalMatch);
        allMatches.UnionWith(verticalMatch);

        return new List<MiniPangTile>(allMatches);
    }
}
