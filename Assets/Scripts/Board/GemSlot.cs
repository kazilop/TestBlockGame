using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GemSlot : MonoBehaviour, IDropHandler
{
    public static GemSlot gemSlot;

    private GameStateGame gameStateGame;

    private void Awake()
    {
        gameStateGame = FindObjectOfType<GameStateGame>();
    }


    public void OnDrop(PointerEventData eventData)
    {
        var item = Block.block;
        
        if(eventData.pointerDrag != null && transform.childCount == 1)
        {
            item.SetItemToSlot(transform);
            string tileName = transform.name;

            if (tileName.StartsWith("Tile:"))
            {
                int x = Convert.ToInt32(tileName.Substring(5).Remove(1));
                int y = Convert.ToInt32(tileName.Substring(6));

                gameStateGame.PutGemInBoard(x, y);
                gameStateGame.CheckBoard();
            }
           
        }
    }
}
