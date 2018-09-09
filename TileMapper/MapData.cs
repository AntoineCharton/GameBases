﻿using UnityEngine;

public class MapData : MonoBehaviour
{
    public GameObject[] Tiles;

    public void SetTiles(int numberOfTiles)
    {
        if (Tiles.Length == numberOfTiles)
            return;

        Tiles = new GameObject[numberOfTiles];
    }

    public GameObject[] GetTiles()
    {
        return Tiles;
    }

    public void AddTile(int id, GameObject gameObject, Vector3 position)
    {
        if (Tiles[id] != null)
            DestroyImmediate(Tiles[id]);

        Tiles[id] = gameObject;
        Tiles[id].transform.parent = this.transform;
        Tiles[id].transform.localPosition = position;
    }

    public void RemoveTile(int id)
    {
        if (Tiles[id] != null)
            DestroyImmediate(Tiles[id]);
    }
}
