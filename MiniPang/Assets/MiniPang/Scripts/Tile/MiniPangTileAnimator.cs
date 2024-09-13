using System.Collections;
using UnityEngine;

public class MiniPangTileAnimator
{
    private MiniPangTile tile;

    public MiniPangTileAnimator(MiniPangTile _tile)
    {
        tile = _tile;
    }

    public void Shake()
    {
        tile.StartCoroutine(ShakeAndDestroy(null));
    }

    private IEnumerator ShakeAndDestroy(System.Action onDestroyed)
    {
        float shakeDuration = 1.0f;
        float shakeAmount = 0.1f;
        Vector3 originalPosition = tile.transform.position;

        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float offsetX = Random.Range(-shakeAmount, shakeAmount);
            float offsetY = Random.Range(-shakeAmount, shakeAmount);

            tile.transform.position = new Vector3(originalPosition.x + offsetX, originalPosition.y + offsetY, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        tile.transform.position = originalPosition;

        Object.Destroy(tile.gameObject);

        onDestroyed?.Invoke();
    }
}
