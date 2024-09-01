using System.Collections;
using UnityEngine;

public class MiniPangBoardUpdater
{
    private MiniPangBoardManager boardManager;

    public MiniPangBoardUpdater(MiniPangBoardManager manager)
    {
        boardManager = manager;
    }

    public IEnumerator UpdateBoard()
    {
        boardManager.DisableAllTileColliders();

        bool moved = false;

        for (int x = 0; x < boardManager.boardSize; x++)
        {
            for (int y = 0; y < boardManager.boardSize; y++)
            {
                if (boardManager.board[x, y] == null)
                {
                    for (int ny = y + 1; ny < boardManager.boardSize; ny++)
                    {
                        if (boardManager.board[x, ny] != null)
                        {
                            boardManager.board[x, y] = boardManager.board[x, ny];
                            boardManager.board[x, ny] = null;
                            boardManager.board[x, y].MoveTo(x, y);
                            moved = true;
                            break;
                        }
                    }
                }
            }
        }

        if (moved)
        {
            yield return new WaitForSeconds(0.5f);
        }

        yield return boardManager.StartCoroutine(FillEmptySpots());

        yield return boardManager.StartCoroutine(boardManager.matchChecker.CheckForMatches());

        boardManager.EnableAllTileColliders();

        yield return boardManager.StartCoroutine(boardManager.tileChecker.CheckPossibleSwaps());
    }

    private IEnumerator FillEmptySpots()
    {
        boardManager.DisableAllTileColliders();

        bool filled = false;

        for (int x = 0; x < boardManager.boardSize; x++)
        {
            for (int y = 0; y < boardManager.boardSize; y++)
            {
                if (boardManager.board[x, y] == null)
                {
                    boardManager.tilePlacer.PlaceRandomTileWithAnimation(x, y);
                    filled = true;
                }
            }
        }

        if (filled)
        {
            yield return new WaitForSeconds(0.5f);
        }

        boardManager.EnableAllTileColliders();
    }
}
