using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPangBoardManager : MonoBehaviour
{
    public int boardSize = 8;
    public GameObject[] objectPrefabs;
    public GameObject boardParent;
    [HideInInspector] public MiniPangScoreUpdater scoreUpdater;
    [HideInInspector] public MiniPangBoardInitializer boardInitializer;
    [HideInInspector] public MiniPangTilePlacer tilePlacer;
    [HideInInspector] public MiniPangMatchChecker matchChecker;
    [HideInInspector] public MiniPangTileDestroyer tileDestroyer;
    [HideInInspector] public MiniPangBoardShuffler boardShuffler;
    [HideInInspector] public MiniPangTileSwapper tileSwapper;
    [HideInInspector] public MiniPangBoardUpdater boardUpdater;
    [HideInInspector] public MiniPangTileChecker tileChecker;

    public MiniPangTile[,] board;

    void Start()
    {

    }

    public void StartGame()
    {
        boardInitializer = new MiniPangBoardInitializer(this);
        tilePlacer = new MiniPangTilePlacer(this, objectPrefabs, boardParent);
        matchChecker = new MiniPangMatchChecker(this);
        tileDestroyer = new MiniPangTileDestroyer(this, scoreUpdater);
        boardShuffler = new MiniPangBoardShuffler(this);
        tileSwapper = new MiniPangTileSwapper(this);
        boardUpdater = new MiniPangBoardUpdater(this);
        tileChecker = new MiniPangTileChecker(this);

        boardInitializer.InitializeBoard();
        StartCoroutine(FillBoardWithAnimation());
    }

    public void SetScoreUpdater(MiniPangScoreUpdater updater)
    {
        scoreUpdater = updater;
    }

    public void InitializeBoard(int boardSize, int blockTypeCount, int requiredScore)
    {
        this.boardSize = boardSize;

        board = new MiniPangTile[boardSize, boardSize];

        foreach (Transform child in boardParent.transform)
        {
            Destroy(child.gameObject);
        }

        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                PlaceRandomTile(x, y, blockTypeCount);
            }
        }
    }


    private void PlaceRandomTile(int x, int y, int blockTypeCount)
    {
        int randomIndex = Random.Range(0, blockTypeCount);
        GameObject tilePrefab = objectPrefabs[randomIndex];

        GameObject tileObject = Instantiate(tilePrefab, boardParent.transform);
        tileObject.transform.localPosition = new Vector3(x, y, 0);

        MiniPangTile tile = tileObject.GetComponent<MiniPangTile>();
        tile.Initialize(x, y, this);

        board[x, y] = tile;
    }


    IEnumerator FillBoardWithAnimation()
    {
        DisableAllTileColliders();

        for (int y = 0; y < boardSize; y++)
        {
            for (int x = 0; x < boardSize; x++)
            {
                tilePlacer.PlaceRandomTileWithAnimation(x, y);
                yield return new WaitForSeconds(0.05f);
            }
        }

        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(matchChecker.CheckForMatches());

        EnableAllTileColliders();
    }

    public void DisableAllTileColliders()
    {
        foreach (var tile in board)
        {
            if (tile != null)
            {
                tile.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    public void EnableAllTileColliders()
    {
        foreach (var tile in board)
        {
            if (tile != null)
            {
                tile.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
