using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPieceLogic
{
    public Pawn(int x, int y, bool is_white) : base(x, y, is_white)
    {
    }

    public new bool ActivateCell(bool[,] possibleMoves, int x, int y, GameState gameState)
    {
        if ((x >= 0) && (x < BoardManager.BOARDSIZE) && (y >= 0) && (y < BoardManager.BOARDSIZE))
        {
            if ((gameState.chessPieces[x, y] == null))
            {
                possibleMoves[x, y] = true;
            }

            return gameState.chessPieces[x, y] == null;
        }

        return false;
    }

    public override bool[,] GetMoves(GameState gameState)
    {
        bool[,] possibleMoves = new bool[BoardManager.BOARDSIZE, BoardManager.BOARDSIZE];

        // Forward
        bool success = ActivateCell(possibleMoves, x, y + (is_white ? 1 : -1), gameState);
        if(success && !has_moved)
        {
            ActivateCell(possibleMoves, x, y + (is_white ? 2 : -2), gameState);
        }

        // Diagonal 1
        if(gameState.chessPieces[x + (is_white ? 1 : -1), y + (is_white ? 1 : -1)] != null)
        {
            if (gameState.chessPieces[x + (is_white ? 1 : -1), y + (is_white ? 1 : -1)].is_white != this.is_white)
            {
                if (((x + (is_white ? 1 : -1)) >= 0) && ((x + (is_white ? 1 : -1)) < BoardManager.BOARDSIZE) && ((y + (is_white ? 1 : -1)) >= 0) && ((y + (is_white ? 1 : -1)) < BoardManager.BOARDSIZE))
                {
                    possibleMoves[x + (is_white ? 1 : -1), y + (is_white ? 1 : -1)] = true;
                }
            }
        }

        // Diagonal 2
        if (gameState.chessPieces[x + (is_white ? -1 : 1), y + (is_white ? 1 : -1)] != null)
        {
            if (gameState.chessPieces[x + (is_white ? -1 : 1), y + (is_white ? 1 : -1)].is_white != this.is_white)
            {
                if (((x + (is_white ? -1 : 1)) >= 0) && ((x + (is_white ? -1 : 1)) < BoardManager.BOARDSIZE) && ((y + (is_white ? 1 : -1)) >= 0) && ((y + (is_white ? 1 : -1)) < BoardManager.BOARDSIZE))
                {
                    possibleMoves[x + (is_white ? -1 : 1), y + (is_white ? 1 : -1)] = true;
                }
            }
        }

        return possibleMoves;
    }
}
