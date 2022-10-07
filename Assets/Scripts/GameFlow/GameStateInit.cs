//   Game State Init

using UnityEngine;

public class GameStateInit : GameState
{
    [SerializeField] private GameObject initUI;

    public override void Construct()
    {
        initUI.SetActive(true);
    }


    public override void Detruct()
    {
        initUI.SetActive(false);
    }

    public void PlayGame()
    {
        brain.ChangeState(GetComponent<GameStateGame>());
    }
}
