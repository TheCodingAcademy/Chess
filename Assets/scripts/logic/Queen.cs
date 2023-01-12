using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPieceLogic
{
    public Queen(int x, int y, bool is_white) : base(x, y, is_white)
    {

    }

    public override bool[,] GetMoves(GameState gameState)
    {
        bool[,] possibleMoves = new bool[BoardManager.BOARDSIZE, BoardManager.BOARDSIZE];

        return possibleMoves;
    }
}
