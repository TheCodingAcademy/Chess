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

        // Diagonals
        int[,] scale_diagonals = { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };

        for (int i = 0; i < scale_diagonals.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++)
            {
                bool success = ActivateCell(possibleMoves, x + j * scale_diagonals[i, 0], y + j * scale_diagonals[i, 1], gameState);
                if (!success)
                {
                    break;
                }
            }
        }

        // Forward
        int[,] scale_forward = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

        for (int i = 0; i < scale_forward.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++)
            {
                bool success = ActivateCell(possibleMoves, x + j * scale_forward[i, 0], y + j * scale_forward[i, 1], gameState);
                if (!success)
                {
                    break;
                }
            }
        }

        return possibleMoves;
    }
}
