using UnityEngine;


public class Board : MonoBehaviour
{
    public static Board Instance { get { return instance; } }
    private static Board instance;

    [SerializeField] private int boardHeight;
    [SerializeField] private int boardWidth;
    [SerializeField] private float offset;

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject gemPrefab;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private Canvas canvas;
    [SerializeField] private float offsetScale;

    private Vector3 startPos;


    private void Awake()
    {
        startPos = transform.position;

        Setup();
    }


    private void Setup()
    {
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                Vector2 pos = new Vector2(startPos.x + x* offset, startPos.y - y*offset );
                GameObject bgTile = Instantiate(tilePrefab, pos, Quaternion.identity);
                bgTile.transform.SetParent(transform, false);
                bgTile.name = "Tile:" + x + y;
            }
        }

    }


    public void UpdateBoard(int x, int y)
    {
        Vector2 pos = Vector2.zero;
        
        string findString = "Tile:" + x + y;
        GameObject newParent = GameObject.Find(findString);
        GameObject newGem = Instantiate(gemPrefab, pos, Quaternion.identity);
        newGem.transform.SetParent(newParent.transform, false);
        newGem.GetComponent<Block>().isMovable = false;
    }


    public void DestroyAll()
    {
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                string findString = "Tile:" + x + y;
                try
                {
                    GameObject toDestroy = GameObject.Find(findString).transform.GetChild(1).gameObject;

                    if (toDestroy != null)
                    {
                        Block block = toDestroy.GetComponent<Block>();
                        Destroy(toDestroy);
                    }
                }
                catch
                {
                    Debug.Log("Can't find object");
                }
            }
        }
    }


    public void DestroyGem(int x, int y)
    {
        Vector2 pos = Vector2.zero;

        string findString = "Tile:" + x + y;
        GameObject toDestroy = GameObject.Find(findString).transform.GetChild(1).gameObject;
        
        Block block = toDestroy.GetComponent<Block>();
        block.PlayDestroy();

        Destroy(toDestroy);
    }


    public void ResetPlayer()
    {
        Vector2 pos = Vector2.zero;
        GameObject newGem = Instantiate(gemPrefab, pos, Quaternion.identity);
        newGem.transform.SetParent(startPoint.transform, false);
        newGem.GetComponent<Block>().isMovable = true;
    }
}
