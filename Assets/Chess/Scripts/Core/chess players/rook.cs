using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rook : ChessPlayerPlacementHandler, IInteractable
{
    public void highlight()
    {

        //movment is like this so that if it encounter another piece it will not highlight anyfurther in that loop

        for (int i = 1; i < 7; i++)
        {
            if (!ChessBoardPlacementHandler.Instance.validatetile(row + i, column)) break;
            ChessBoardPlacementHandler.Instance.Highlight(row + i, column);
        }

        for (int i = 1; i < 7; i++)
        {
            if (!ChessBoardPlacementHandler.Instance.validatetile(row - i, column)) break;
            ChessBoardPlacementHandler.Instance.Highlight(row - i, column);
        }

        for (int i = 1; i < 7; i++)
        {
            if (!ChessBoardPlacementHandler.Instance.validatetile(row, column + i)) break;
            ChessBoardPlacementHandler.Instance.Highlight(row, column + i);
        }

        for (int i = 1; i < 7; i++)
        {
            if (!ChessBoardPlacementHandler.Instance.validatetile(row, column - i)) break;
            ChessBoardPlacementHandler.Instance.Highlight(row, column - i);
        }
    }
}
