public class MiniPangBoardInitializer
{
    private MiniPangBoardManager boardManager;

    public MiniPangBoardInitializer(MiniPangBoardManager manager)
    {
        boardManager = manager;
    }

    public void InitializeBoard()
    {
        boardManager.board = new MiniPangTile[boardManager.boardSize, boardManager.boardSize];
    }
}
