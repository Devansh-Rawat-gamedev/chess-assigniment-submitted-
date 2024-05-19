using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queen : ChessPlayerPlacementHandler, IInteractable
{
    public void highlight()
    {
        //rook's movement
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

        //bhisop's movement

        for (int i = 1; i < 7; i++)
        {
            if (!ChessBoardPlacementHandler.Instance.validatetile(row + i, column + i)) break;
            ChessBoardPlacementHandler.Instance.Highlight(row + i, column + i);
        }

        for (int i = 1; i < 7; i++)
        {
            if (!ChessBoardPlacementHandler.Instance.validatetile(row - i, column - i)) break;
            ChessBoardPlacementHandler.Instance.Highlight(row - i, column - i);
        }

        for (int i = 1; i < 7; i++)
        {
            if (!ChessBoardPlacementHandler.Instance.validatetile(row - i, column + i)) break;
            ChessBoardPlacementHandler.Instance.Highlight(row - i, column + i);
        }

        for (int i = 1; i < 7; i++)
        {
            if (!ChessBoardPlacementHandler.Instance.validatetile(row + i, column - i)) break;
            ChessBoardPlacementHandler.Instance.Highlight(row + i, column - i);
        }


    }
}
