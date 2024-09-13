using System.Collections;
using UnityEngine;

public class MiniPangTilePlacer
{
    private MiniPangBoardManager boardManager;
    private GameObject[] objectPrefabs;
    private GameObject boardParent;

    public MiniPangTilePlacer(MiniPangBoardManager manager, GameObject[] prefabs, GameObject parent)
    {
        boardManager = manager;
        objectPrefabs = prefabs;
        boardParent = parent;
    }

    public void PlaceRandomTileWithAnimation(int x, int y)
    {
        int randomIndex = Random.Range(0, objectPrefabs.Length);

        float offsetX = -(boardManager.boardSize - 1) / 2.0f;
        float offsetY = -(boardManager.boardSize - 1) / 2.0f;
        Vector3 startPosition = new Vector3(x + offsetX, y + offsetY + boardManager.boardSize, 0);
        Vector3 targetPosition = new Vector3(x + offsetX, y + offsetY, 0);

        GameObject tileObj = Object.Instantiate(objectPrefabs[randomIndex], startPosition, Quaternion.identity);
        tileObj.transform.rotation = Quaternion.Euler(0, 180, 0);
        tileObj.transform.parent = boardParent.transform;

        MiniPangTile tile = tileObj.GetComponent<MiniPangTile>();
        tile.Initialize(x, y, boardManager);

        boardManager.StartCoroutine(SmoothMove(tileObj.transform, targetPosition, 0.5f));

        boardManager.board[x, y] = tile;
    }

    private IEnumerator SmoothMove(Transform tileTransform, Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = tileTransform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            tileTransform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        tileTransform.position = targetPosition;
    }
}
