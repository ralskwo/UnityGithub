using System.Collections;
using UnityEngine;

public class MiniPangTileMover
{
    private MiniPangTile tile;
    private MiniPangBoardManager boardManager;

    public MiniPangTileMover(MiniPangTile _tile, MiniPangBoardManager _boardManager)
    {
        tile = _tile;
        boardManager = _boardManager;
    }

    public void MoveTo(int newX, int newY)
    {
        tile.SetPosition(newX, newY);

        float offsetX = -(boardManager.boardSize - 1) / 2.0f;
        float offsetY = -(boardManager.boardSize - 1) / 2.0f;
        Vector3 targetPosition = new Vector3(newX + offsetX, newY + offsetY, 0);

        boardManager.StartCoroutine(SmoothMove(tile.transform, targetPosition));
    }

    private IEnumerator SmoothMove(Transform tileTransform, Vector3 targetPosition)
    {
        Vector3 startPosition = tileTransform.position;
        float elapsed = 0f;
        float duration = 0.3f;

        while (elapsed < duration)
        {
            tileTransform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        tileTransform.position = targetPosition;
    }
}
