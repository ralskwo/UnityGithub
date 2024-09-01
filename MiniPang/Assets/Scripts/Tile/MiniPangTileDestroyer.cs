using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPangTileDestroyer
{
    private MiniPangBoardManager boardManager;
    private MiniPangScoreUpdater scoreUpdater;

    public MiniPangTileDestroyer(MiniPangBoardManager manager, MiniPangScoreUpdater updater)
    {
        boardManager = manager;
        scoreUpdater = updater;
    }

    public IEnumerator DestroyAllMatchedTiles(List<MiniPangTile> matchedTiles)
    {
        HashSet<MiniPangTile> uniqueTiles = new HashSet<MiniPangTile>(matchedTiles);

        int matchedCount = uniqueTiles.Count;

        foreach (var tile in uniqueTiles)
        {
            if (tile != null)
            {
                boardManager.board[tile.x, tile.y] = null;
            }
        }

        foreach (var tile in uniqueTiles)
        {
            if (tile != null)
            {
                tile.Shake();
            }
        }

        yield return new WaitForSeconds(1f);

        foreach (var tile in uniqueTiles)
        {
            if (tile != null)
            {
                Object.Destroy(tile.gameObject);
            }
        }

        // 점수 추가를 직접 하지 않고, 매칭된 타일의 수를 전달
        if (scoreUpdater != null)
        {
            scoreUpdater.OnTilesDestroyed(matchedCount); // 매칭된 타일 수 전달
        }

        yield return boardManager.boardUpdater.UpdateBoard(); // 보드 업데이트
    }
}
