using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    private static GameManager instance;
        
    private GameState state;


    private void Start()
    {
        instance = this;
        state = GetComponent<GameStateInit>();
        state.Construct();
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

}
