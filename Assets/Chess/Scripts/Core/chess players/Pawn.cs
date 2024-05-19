using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPlayerPlacementHandler, IInteractable
{

    int reach = 1;
    public void highlight()
    {

        if (row == 1) reach = 2;
        else reach = 1;

        for (int i = 1; i <= reach; i++) { 
            if(!ChessBoardPlacementHandler.Instance.validatetile(row + i, column))  break;
            
        ChessBoardPlacementHandler.Instance.Highlight(row + i, column);

    }
            
 
    }

}



