using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    private static GameManager instance;
        
    private GameState state;

    private Board boardComponent;

    private int boardSize = 3;
    private int[,] board;
    private int winScore = 3;


    private void Start()
    {
        instance = this;
        state = GetComponent<GameStateInit>();
        state.Construct();

       /* board = new int[boardSize, boardSize];
        boardComponent = FindObjectOfType<Board>();

        ClearBoard();
        // Test Data
        board[0, 1] = board[2, 1] = 1;

        boardComponent.UpdateBoard(0,1);
        boardComponent.UpdateBoard(2,1); */
    }


    private void Update()
    {
        state.UpdateState();
    }

    public void ChangeState(GameState s)
    {
        state.Detruct();
        state = s;
        state.Construct();
    }


  /*  public void PutGemInBoard(int x, int y)
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


    private void ClearBoard()
    {
        for (int x = 0; x < board.GetLength(0); x++)
            for (int y = 0; y < board.GetLength(1); y++)
            {
                board[x, y] = 0;
            }
    }
  */
}
