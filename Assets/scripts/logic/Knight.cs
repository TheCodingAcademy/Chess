using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPieceLogic
{
    public Knight(int x, int y, bool is_white) : base(x, y, is_white){}
    public Knight(int x, int y, bool is_white, bool has_moved) : base(x, y, is_white, has_moved) { }

    public override bool[,] GetMoves(GameState gameState, bool isRecursive)
    {
        bool[,] possibleMoves = new bool[BoardManager.BOARDSIZE, BoardManager.BOARDSIZE];

        ActivateCell(possibleMoves, x - 1, y + 2, gameState, isRecursive);
        ActivateCell(possibleMoves, x + 1, y + 2, gameState, isRecursive);
        ActivateCell(possibleMoves, x - 1, y - 2, gameState, isRecursive);
        ActivateCell(possibleMoves, x + 1, y - 2, gameState, isRecursive);
        ActivateCell(possibleMoves, x + 2, y + 1, gameState, isRecursive);
        ActivateCell(possibleMoves, x + 2, y - 1, gameState, isRecursive);
        ActivateCell(possibleMoves, x - 2, y + 1, gameState, isRecursive);
        ActivateCell(possibleMoves, x - 2, y - 1, gameState, isRecursive);

        return possibleMoves;
    }

    public override ChessPieceLogic Clone()
    {
        return new Knight(x, y, is_white, has_moved);
    }
}
