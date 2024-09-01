using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPangBoardShuffler
{
    private MiniPangBoardManager boardManager;

    public MiniPangBoardShuffler(MiniPangBoardManager manager)
    {
        boardManager = manager;
    }

    public IEnumerator ShuffleBoard()
    {
        boardManager.DisableAllTileColliders();

        List<MiniPangTile> allTiles = new List<MiniPangTile>();

        for (int y = 0; y < boardManager.boardSize; y++)
        {
            for (int x = 0; x < boardManager.boardSize; x++)
            {
                if (boardManager.board[x, y] != null)
                {
                    allTiles.Add(boardManager.board[x, y]);
                    boardManager.board[x, y] = null;
                }
            }
        }

        ShuffleList(allTiles);

        int index = 0;
        for (int y = 0; y < boardManager.boardSize; y++)
        {
            for (int x = 0; x < boardManager.boardSize; x++)
            {
                if (index < allTiles.Count)
                {
                    boardManager.board[x, y] = allTiles[index];
                    boardManager.board[x, y].MoveTo(x, y);
                    index++;
                }
            }
        }

        yield return new WaitForSeconds(0.5f);

        boardManager.EnableAllTileColliders();

        yield return boardManager.StartCoroutine(boardManager.matchChecker.CheckForMatches());
    }

    private void ShuffleList(List<MiniPangTile> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            MiniPangTile temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
