using System.Collections.Generic;

public static class MiniPangMatchUtility
{
    public static List<MiniPangTile> FindHorizontalMatch(MiniPangBoardManager boardManager, MiniPangTile tile)
    {
        List<MiniPangTile> match = new List<MiniPangTile> { tile };

        for (int i = tile.x - 1; i >= 0; i--)
        {
            if (boardManager.board[i, tile.y] != null && boardManager.board[i, tile.y].type == tile.type)
            {
                match.Add(boardManager.board[i, tile.y]);
            }
            else
            {
                break;
            }
        }

        for (int i = tile.x + 1; i < boardManager.boardSize; i++)
        {
            if (boardManager.board[i, tile.y] != null && boardManager.board[i, tile.y].type == tile.type)
            {
                match.Add(boardManager.board[i, tile.y]);
            }
            else
            {
                break;
            }
        }

        return match.Count >= 3 ? match : new List<MiniPangTile>();
    }

    public static List<MiniPangTile> FindVerticalMatch(MiniPangBoardManager boardManager, MiniPangTile tile)
    {
        List<MiniPangTile> match = new List<MiniPangTile> { tile };

        for (int i = tile.y - 1; i >= 0; i--)
        {
            if (boardManager.board[tile.x, i] != null && boardManager.board[tile.x, i].type == tile.type)
            {
                match.Add(boardManager.board[tile.x, i]);
            }
            else
            {
                break;
            }
        }

        for (int i = tile.y + 1; i < boardManager.boardSize; i++)
        {
            if (boardManager.board[tile.x, i] != null && boardManager.board[tile.x, i].type == tile.type)
            {
                match.Add(boardManager.board[tile.x, i]);
            }
            else
            {
                break;
            }
        }

        return match.Count >= 3 ? match : new List<MiniPangTile>();
    }
}
