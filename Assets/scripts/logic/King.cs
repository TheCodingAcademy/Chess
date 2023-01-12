using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPieceLogic
{
    public King(int x, int y, bool is_white) : base(x, y, is_white)
    {

    }

    public override bool[,] GetMoves(GameState gameState)
    {
        bool[,] possibleMoves = new bool[BoardManager.BOARDSIZE, BoardManager.BOARDSIZE];

        ActivateCell(possibleMoves, x - 1, y, gameState);
        ActivateCell(possibleMoves, x + 1, y, gameState);
        ActivateCell(possibleMoves, x, y - 1, gameState);
        ActivateCell(possibleMoves, x, y + 1, gameState);
        ActivateCell(possibleMoves, x + 1, y + 1, gameState);
        ActivateCell(possibleMoves, x + 1, y - 1, gameState);
        ActivateCell(possibleMoves, x - 1, y + 1, gameState);
        ActivateCell(possibleMoves, x - 1, y - 1, gameState);

        return possibleMoves;
    }
}
