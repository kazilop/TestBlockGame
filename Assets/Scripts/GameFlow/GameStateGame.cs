// Game State Game

using UnityEngine;

public class GameStateGame : GameState
{
    [SerializeField] private GameObject gameUI;

    private Board boardComponent;

    private int boardSize = 3;
    private int[,] board;
    private int winScore = 3;

    public override void Construct()
    {
        gameUI.SetActive(true);

        board = new int[boardSize, boardSize];
        boardComponent = FindObjectOfType<Board>();

        ClearBoard();
        // Test Data
        board[0, 1] = board[2, 1] = 1;

        boardComponent.UpdateBoard(0, 1);
        boardComponent.UpdateBoard(2, 1);
    }


    public override void Detruct()
    {
        gameUI.SetActive(false);
    }

    private void ClearBoard()
    {
        for (int x = 0; x < board.GetLength(0); x++)
            for (int y = 0; y < board.GetLength(1); y++)
            {
                board[x, y] = 0;
            }
    }

    public void PutGemInBoard(int x, int y)
    {
        board[x, y] = 1;
    }


    public int[,] ReturnBoard()
    {
        return board;
    }

    public void CheckBoard()
    {


        for (int y = 0; y < board.GetLength(1); y++)
        {
            int checkResult = 0;

            for (int x = 0; x < board.GetLength(0); x++)
            {
                checkResult += board[x, y];
            }

            if (checkResult == winScore)
            {
                // state = GetComponent<GameStateWin>();
                Debug.Log("W I N");
                return;
            }
        }

        Debug.Log("FAIL ");
        // state = GetComponent<GameStateFail>();
    }

}
