using UnityEngine;


public class GameStateWin : GameState
{
    [SerializeField] private GameObject winUI;


    public override void Construct()
    {
        winUI.SetActive(true);
    }


    public override void Detruct()
    {
        winUI.SetActive(false);
    }


    public void PlayAgain()
    {
        brain.ChangeState(GetComponent<GameStateGame>());
    }
}
