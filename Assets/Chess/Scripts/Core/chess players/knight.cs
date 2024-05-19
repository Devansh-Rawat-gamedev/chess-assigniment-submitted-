using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : ChessPlayerPlacementHandler, IInteractable
{
    public void highlight()
    {
        if (ChessBoardPlacementHandler.Instance.validatetile(row + 2, column + 1))
        ChessBoardPlacementHandler.Instance.Highlight(row +2, column + 1);

        if (ChessBoardPlacementHandler.Instance.validatetile(row + 2, column - 1))
            ChessBoardPlacementHandler.Instance.Highlight(row + 2, column - 1);

        if (ChessBoardPlacementHandler.Instance.validatetile(row + 1, column + 2))
            ChessBoardPlacementHandler.Instance.Highlight(row + 1, column + 2);

        if (ChessBoardPlacementHandler.Instance.validatetile(row - 1, column + 2))
            ChessBoardPlacementHandler.Instance.Highlight(row - 1, column + 2);
    }

}
