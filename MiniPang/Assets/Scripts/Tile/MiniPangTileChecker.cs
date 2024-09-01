using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPangTileChecker : MonoBehaviour
{
    private MiniPangBoardManager boardManager;

    public MiniPangTileChecker(MiniPangBoardManager manager)
    {
        boardManager = manager;
    }

    public IEnumerator CheckPossibleSwaps()
    {
        yield return new WaitForSeconds(0.1f);

        bool possibleSwapFound = false;

        for (int y = 0; y < boardManager.boardSize; y++)
        {
            for (int x = 0; x < boardManager.boardSize; x++)
            {
                if (boardManager.board[x, y] != null)
                {
                    if (x < boardManager.boardSize - 1 && boardManager.board[x + 1, y] != null)
                    {
                        boardManager.tileSwapper.SwapTiles(boardManager.board[x, y], boardManager.board[x + 1, y]);

                        List<MiniPangTile> match1Horizontal = MiniPangMatchUtility.FindHorizontalMatch(boardManager, boardManager.board[x, y]);
                        List<MiniPangTile> match1Vertical = MiniPangMatchUtility.FindVerticalMatch(boardManager, boardManager.board[x, y]);
                        List<MiniPangTile> match2Horizontal = MiniPangMatchUtility.FindHorizontalMatch(boardManager, boardManager.board[x + 1, y]);
                        List<MiniPangTile> match2Vertical = MiniPangMatchUtility.FindVerticalMatch(boardManager, boardManager.board[x + 1, y]);

                        if (match1Horizontal.Count >= 3 || match1Vertical.Count >= 3 ||
                            match2Horizontal.Count >= 3 || match2Vertical.Count >= 3)
                        {
                            possibleSwapFound = true;
                        }

                        boardManager.tileSwapper.SwapTiles(boardManager.board[x, y], boardManager.board[x + 1, y]);
                    }

                    if (y < boardManager.boardSize - 1 && boardManager.board[x, y + 1] != null)
                    {
                        boardManager.tileSwapper.SwapTiles(boardManager.board[x, y], boardManager.board[x, y + 1]);

                        List<MiniPangTile> match1Horizontal = MiniPangMatchUtility.FindHorizontalMatch(boardManager, boardManager.board[x, y]);
                        List<MiniPangTile> match1Vertical = MiniPangMatchUtility.FindVerticalMatch(boardManager, boardManager.board[x, y]);
                        List<MiniPangTile> match2Horizontal = MiniPangMatchUtility.FindHorizontalMatch(boardManager, boardManager.board[x, y + 1]);
                        List<MiniPangTile> match2Vertical = MiniPangMatchUtility.FindVerticalMatch(boardManager, boardManager.board[x, y + 1]);

                        if (match1Horizontal.Count >= 3 || match1Vertical.Count >= 3 ||
                            match2Horizontal.Count >= 3 || match2Vertical.Count >= 3)
                        {
                            possibleSwapFound = true;
                        }

                        boardManager.tileSwapper.SwapTiles(boardManager.board[x, y], boardManager.board[x, y + 1]);
                    }
                }
            }
        }

        if (!possibleSwapFound)
        {
            yield return boardManager.StartCoroutine(boardManager.boardShuffler.ShuffleBoard());
            yield return StartCoroutine(CheckPossibleSwaps());
        }
    }
}
