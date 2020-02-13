﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node> {
    public int iGridX;//X Position in the Node Array
    public int iGridY;//Y Position in the Node Array

    public bool bIsWall;//Tells the program if this node is being obstructed.
    public Vector3 vPosition;//The world position of the node.

    public Node ParentNode;//For the AStar algoritm, will store what node it previously came from so it cn trace the shortest path.
    int heapIndex;

    public int igCost;//The cost of moving to the next square.
    public int ihCost;//The distance to the goal from this node.

    public int FCost { get { return igCost + ihCost; } }//Quick get function to add G cost and H Cost, and since we'll never need to edit FCost, we dont need a set function.

    public Node(bool a_bIsWall, Vector3 a_vPos, int a_igridX, int a_igridY)//Constructor
    {
        bIsWall = a_bIsWall;//Tells the program if this node is being obstructed.
        vPosition = a_vPos;//The world position of the node.
        iGridX = a_igridX;//X Position in the Node Array
        iGridY = a_igridY;//Y Position in the Node Array
    }

    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }
        set
        {
            heapIndex = value;
        }
    }

    public int CompareTo(Node nodeToCompare)
    {
        int compare = FCost.CompareTo(nodeToCompare.FCost);
        if (compare == 0)
        {
            compare = ihCost.CompareTo(nodeToCompare.ihCost);
        }
        return -compare;
    }

}
