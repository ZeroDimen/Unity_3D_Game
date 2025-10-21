using System.Collections.Generic;
using UnityEngine;


public class Room
{
    public int Id {get; private set;}
    public List<Room> Neighbors {get; private set;}
    public GameObject roomInstance;

    public Room(int id)
    {
        roomInstance = null;
        Id = id;
        Neighbors = new List<Room>();
    }
    
    public void AddNeighbour(Room room)
    {
        if (!Neighbors.Contains(room))
        {
            Neighbors.Add(room);
            room.AddNeighbour(this);
        }
    }

    public void RemoveNeighbour(Room room)
    {
        if (Neighbors.Contains(room))
        {
            Neighbors.Remove(room);
            room.RemoveNeighbour(this);
        }
    }
}
