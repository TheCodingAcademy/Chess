using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // Cells
    public GameObject blackCell;
    public GameObject whiteCell;

    // Black pieces
    public GameObject blackPawn;
    public GameObject blackKing;
    public GameObject blackQueen;
    public GameObject blackBishop;
    public GameObject blackKnight;
    public GameObject blackRock;

    // White pieces
    public GameObject whitePawn;
    public GameObject whiteKing;
    public GameObject whiteQueen;
    public GameObject whiteBishop;
    public GameObject whiteKnight;
    public GameObject whiteRock;

    private const int BOARDSIZE = 8;

    void Start()
    {
        InstantiateBoard();
        InstantiateChessPieces();
    }

    void InstantiateChessPieces()
    {
        InstantiateWhitePieces();
        InstantiateBlackPieces();
    }

    void InstantiateWhitePieces()
    {
        Instantiate(whiteRock, new Vector3(0, 0.0f, 0), new Quaternion());
        Instantiate(whiteRock, new Vector3(BOARDSIZE - 1, 0.0f, 0), new Quaternion());

        Instantiate(whiteKnight, new Vector3(1, 0.0f, 0), new Quaternion());
        Instantiate(whiteKnight, new Vector3(BOARDSIZE - 2, 0.0f, 0), new Quaternion());

        Instantiate(whiteBishop, new Vector3(2, 0.0f, 0), new Quaternion());
        Instantiate(whiteBishop, new Vector3(BOARDSIZE - 3, 0.0f, 0), new Quaternion());

        Instantiate(whiteKing, new Vector3(3, 0.0f, 0), new Quaternion());
        Instantiate(whiteQueen, new Vector3(4, 0.0f, 0), new Quaternion());

        for (int i = 0; i < BOARDSIZE; i++)
        {
            Instantiate(whitePawn, new Vector3(i, 0.0f, 1), new Quaternion());
        }
    }

    void InstantiateBlackPieces()
    {
        Instantiate(blackRock, new Vector3(0, 0.0f, BOARDSIZE - 1), new Quaternion());
        Instantiate(blackRock, new Vector3(BOARDSIZE - 1, 0.0f, BOARDSIZE - 1), new Quaternion());

        Instantiate(blackKnight, new Vector3(1, 0.0f, BOARDSIZE - 1), new Quaternion());
        Instantiate(blackKnight, new Vector3(BOARDSIZE - 2, 0.0f, BOARDSIZE - 1), new Quaternion());

        Instantiate(blackBishop, new Vector3(2, 0.0f, BOARDSIZE - 1), new Quaternion());
        Instantiate(blackBishop, new Vector3(BOARDSIZE - 3, 0.0f, BOARDSIZE - 1), new Quaternion());

        Instantiate(blackKing, new Vector3(3, 0.0f, BOARDSIZE - 1), new Quaternion());
        Instantiate(blackQueen, new Vector3(4, 0.0f, BOARDSIZE - 1), new Quaternion());

        for(int i=0; i<BOARDSIZE; i++)
        {
            Instantiate(blackPawn, new Vector3(i, 0.0f, BOARDSIZE - 2), new Quaternion());
        }

    }

    void InstantiateBoard()
    {
        for (int j = 0; j < BOARDSIZE; j++)
        {
            for (int i = 0; i < BOARDSIZE; i++)
            {
                if((i % 2) == (j % 2))
                {
                    Instantiate(blackCell, new Vector3(i, 0.0f, j), new Quaternion());
                }
                else
                {
                    Instantiate(whiteCell, new Vector3(i, 0.0f, j), new Quaternion());
                }
            }
        }
    }
}
