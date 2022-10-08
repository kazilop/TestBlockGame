using UnityEngine;

public class GameStateLose : GameState
{
    [SerializeField] private GameObject loseUI;


    public override void Construct()
    {
        loseUI.SetActive(true);
    }


    public override void Detruct()
    {
        loseUI.SetActive(false);
    }


    public void PlayAgain()
    {
        brain.ChangeState(GetComponent<GameStateGame>());
    }
}
