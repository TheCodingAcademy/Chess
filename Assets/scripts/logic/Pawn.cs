using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPieceLogic
{
    public Pawn(int x, int y, bool is_white) : base(x, y, is_white){}
    public Pawn(int x, int y, bool is_white, bool has_moved) : base(x, y, is_white, has_moved) { }


    public new bool ActivateCell(bool[,] possibleMoves, int nextX, int nextY, GameState gameState, bool isRecursive)
    {
        if ((nextX >= 0) && (nextX < BoardManager.BOARDSIZE) && (nextY >= 0) && (nextY < BoardManager.BOARDSIZE))
        {
            if ((gameState.chessPieces[nextX, nextY] == null))
            {
                possibleMoves[nextX, nextY] = true;

                if (!isRecursive)
                {
                    GameState newGameState = gameState.Move(x, y, nextX, nextY);
                    if (newGameState.isInChess(is_white))
                    {
                        possibleMoves[nextX, nextY] = false;
                    }
                }
            }

            return gameState.chessPieces[nextX, nextY] == null;
        }

        return false;
    }

    public override bool[,] GetMoves(GameState gameState, bool isRecursive)
    {
        bool[,] possibleMoves = new bool[BoardManager.BOARDSIZE, BoardManager.BOARDSIZE];

        // Forward
        bool success = ActivateCell(possibleMoves, x, y + (is_white ? 1 : -1), gameState, isRecursive);
        if(success && !has_moved)
        {
            ActivateCell(possibleMoves, x, y + (is_white ? 2 : -2), gameState, isRecursive);
        }

        // Diagonal 1
        if (((x + (is_white ? 1 : -1)) >= 0) && ((x + (is_white ? 1 : -1)) < BoardManager.BOARDSIZE) && ((y + (is_white ? 1 : -1)) >= 0) && ((y + (is_white ? 1 : -1)) < BoardManager.BOARDSIZE))
        {
            if (gameState.chessPieces[x + (is_white ? 1 : -1), y + (is_white ? 1 : -1)] != null)
            {
                if (gameState.chessPieces[x + (is_white ? 1 : -1), y + (is_white ? 1 : -1)].is_white != this.is_white)
                {
                    possibleMoves[x + (is_white ? 1 : -1), y + (is_white ? 1 : -1)] = true;

                    if (!isRecursive)
                    {
                        GameState newGameState = gameState.Move(x, y, x + (is_white ? 1 : -1), y + (is_white ? 1 : -1));
                        if (newGameState.isInChess(is_white))
                        {
                            possibleMoves[x + (is_white ? 1 : -1), y + (is_white ? 1 : -1)] = false;
                        }
                    }
                }
            }
        }

        // Diagonal 2
        if (((x + (is_white ? -1 : 1)) >= 0) && ((x + (is_white ? -1 : 1)) < BoardManager.BOARDSIZE) && ((y + (is_white ? 1 : -1)) >= 0) && ((y + (is_white ? 1 : -1)) < BoardManager.BOARDSIZE))
        {
            if (gameState.chessPieces[x + (is_white ? -1 : 1), y + (is_white ? 1 : -1)] != null)
            {
                if (gameState.chessPieces[x + (is_white ? -1 : 1), y + (is_white ? 1 : -1)].is_white != this.is_white)
                {
                    possibleMoves[x + (is_white ? -1 : 1), y + (is_white ? 1 : -1)] = true;

                    if (!isRecursive)
                    {
                        GameState newGameState = gameState.Move(x, y, x + (is_white ? -1 : 1), y + (is_white ? 1 : -1));
                        if (newGameState.isInChess(is_white))
                        {
                            possibleMoves[x + (is_white ? -1 : 1), y + (is_white ? 1 : -1)] = false;
                        }
                    }
                }
            }
        }

        return possibleMoves;
    }

    public override ChessPieceLogic Clone()
    {
        return new Pawn(x, y, is_white, has_moved);
    }

}
