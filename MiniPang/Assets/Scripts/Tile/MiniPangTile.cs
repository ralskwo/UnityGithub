using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPangTile : MonoBehaviour
{
    public int x, y;
    public string type;
    private MiniPangBoardManager boardManager;
    private MiniPangTileMover tileMover;
    private MiniPangTileAnimator tileAnimator;
    private MiniPangTileInputHandler tileInputHandler;
    private static MiniPangTile selectedTile = null;

    public void Initialize(int _x, int _y, MiniPangBoardManager _boardManager)
    {
        x = _x;
        y = _y;
        boardManager = _boardManager;
        type = gameObject.name.Replace("(Clone)", "").Trim();

        tileMover = new MiniPangTileMover(this, boardManager);
        tileAnimator = new MiniPangTileAnimator(this);
        tileInputHandler = new MiniPangTileInputHandler(this, boardManager);
    }

    public void MoveTo(int newX, int newY)
    {
        tileMover.MoveTo(newX, newY);
    }

    public void Shake()
    {
        tileAnimator.Shake();
    }

    void OnMouseDown()
    {
        tileInputHandler.HandleInput(ref selectedTile);
    }

    public void SetPosition(int newX, int newY)
    {
        x = newX;
        y = newY;
    }
}
