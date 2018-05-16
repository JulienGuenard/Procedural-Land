using System;
using System.Collections.Generic;

public class Master_Room {
    
    private Random currentSeed;
    private int dungeonWidth;
    private int dungeonHeight;
    private Room currentRoom;
    private int minimalSize = 3;
    private List<Room> intermediateRooms = new List<Room>();
    private List<Room> roomsGenerated = new List<Room>();

    public void data_in(Int32 seed, int width, int height)
    {
        currentSeed = new Random(seed);
        dungeonWidth = width;
        dungeonHeight = height;
    }

    public void phase_begin()
    {
        intermediateRooms.Add(new Room(0, 0, dungeonWidth, dungeonHeight));
    }

    public void phase_update()
    {
        if (intermediateRooms.Count > 0)
        {
            currentRoom = intermediateRooms[0];
            if (currentRoom.x + minimalSize <= currentRoom.width - minimalSize)
            {
                int newX = currentSeed.Next(currentRoom.x + minimalSize, currentRoom.width - minimalSize);
                intermediateRooms.Add(new Room(currentRoom.x, currentRoom.y, newX - currentRoom.x + 1, currentRoom.height));
                intermediateRooms.Add(new Room(newX, currentRoom.y, currentRoom.width - (newX - currentRoom.x), currentRoom.height));
            }
            else if (currentRoom.y + minimalSize <= currentRoom.height - minimalSize)
            {
                int newY = currentSeed.Next(currentRoom.y + minimalSize, currentRoom.height - minimalSize);
                intermediateRooms.Add(new Room(currentRoom.x, currentRoom.y, currentRoom.width, newY - currentRoom.y + 1));
                intermediateRooms.Add(new Room(currentRoom.x, newY, currentRoom.width, currentRoom.height - (newY - currentRoom.y)));
            }
            else
            {
                roomsGenerated.Add(currentRoom);
            }
            intermediateRooms.Remove(currentRoom);
            phase_update();
        }
    }

    public void phase_end()
    {

    }

    public void view()
    {

    }

    public List<Room> data_out()
    {
        return roomsGenerated;
    }

    public void kill()
    {

    }

    public static void draw_layer_txt(char[,] arr_tile, List<Room> list_room)
    {
        foreach (Room room in list_room)
        {
            for (int i = room.x; i < room.x + room.width; i++)
            {
                for (int j = room.y; j < room.y + room.height; j++)
                {
                    if (i == room.x || i == room.x + room.width - 1 || j == room.y || j == room.y + room.height - 1)
                    {
                        arr_tile[i, j] = '1';
                    }
                }
            }
        }
    }
}
