using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPieceLogic
{
    public King(int x, int y, bool is_white) : base(x, y, is_white){}
    public King(int x, int y, bool is_white, bool has_moved) : base(x, y, is_white, has_moved) { }

    public override bool[,] GetMoves(GameState gameState, bool isRecursive)
    {
        bool[,] possibleMoves = new bool[BoardManager.BOARDSIZE, BoardManager.BOARDSIZE];

        ActivateCell(possibleMoves, x - 1, y, gameState, isRecursive);
        ActivateCell(possibleMoves, x + 1, y, gameState, isRecursive);
        ActivateCell(possibleMoves, x, y - 1, gameState, isRecursive);
        ActivateCell(possibleMoves, x, y + 1, gameState, isRecursive);
        ActivateCell(possibleMoves, x + 1, y + 1, gameState, isRecursive);
        ActivateCell(possibleMoves, x + 1, y - 1, gameState, isRecursive);
        ActivateCell(possibleMoves, x - 1, y + 1, gameState, isRecursive);
        ActivateCell(possibleMoves, x - 1, y - 1, gameState, isRecursive);

        if (!isRecursive)
        {
            if (!has_moved)
            {
                ChessPieceLogic leftRock = gameState.chessPieces[0, y];
                ChessPieceLogic rightRock = gameState.chessPieces[BoardManager.BOARDSIZE - 1, y];

                // Small Rock
                if ((rightRock != null) && (!rightRock.has_moved))
                {
                    // Not in chess
                    if ((!gameState.isInChess(is_white)) && (!gameState.isInChess(is_white, rightRock.GetX(), rightRock.GetY())))
                    {
                        bool rock_possible = true;
                        for (int x_ = 5; x_ <= 6; x_++)
                        {
                            if (gameState.chessPieces[x_, y] == null)
                            {
                                if (gameState.isInChess(is_white, x_, y))
                                {
                                    rock_possible = false;
                                    break;
                                }
                            }
                            else
                            {
                                rock_possible = false;
                                break;
                            }
                        }

                        if (rock_possible)
                        {
                            possibleMoves[6, y] = true;
                        }
                    }
                }

                // Large Rock
            }
        }
      
        return possibleMoves;
    }

    public override ChessPieceLogic Clone()
    {
        return new King(x, y, is_white, has_moved);
    }
}
