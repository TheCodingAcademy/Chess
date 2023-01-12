using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPieceLogic
{
    public Knight(int x, int y, bool is_white) : base(x, y, is_white){}

    public override bool[,] GetMoves(GameState gameState)
    {
        bool[,] possibleMoves = new bool[BoardManager.BOARDSIZE, BoardManager.BOARDSIZE];

        ActivateCell(possibleMoves, x - 1, y + 2, gameState);
        ActivateCell(possibleMoves, x + 1, y + 2, gameState);
        ActivateCell(possibleMoves, x - 1, y - 2, gameState);
        ActivateCell(possibleMoves, x + 1, y - 2, gameState);
        ActivateCell(possibleMoves, x + 2, y + 1, gameState);
        ActivateCell(possibleMoves, x + 2, y - 1, gameState);
        ActivateCell(possibleMoves, x - 2, y + 1, gameState);
        ActivateCell(possibleMoves, x - 2, y - 1, gameState);

        return possibleMoves;
    }
}
