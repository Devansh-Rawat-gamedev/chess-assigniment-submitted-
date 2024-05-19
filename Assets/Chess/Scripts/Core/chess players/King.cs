using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPlayerPlacementHandler, IInteractable
{

    public void highlight()
    {
        
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)   continue;

                if (!ChessBoardPlacementHandler.Instance.validatetile(row + j, column + i)) continue;
                ChessBoardPlacementHandler.Instance.Highlight(row + j, column+i);
            }
        }
    }
}
