using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dungeon;

public class Master_Web : MonoBehaviour {

  List<Room> list_room;

  public void data_in(List<Room> list_room)
  {
    this.list_room = list_room;
  }

  public void phase_begin()
  {

  }

  public void phase_update()
  {
    Room roomTest1 = new Room(0, 0, 3, 4);
    Room roomTest2 = new Room(0, 3, 7, 8);

    Master_Dungeon.debug("First room : x :" + roomTest1.x + ", y :" + roomTest1.y + " , width :" + roomTest1.width + ", height : " + roomTest1.height);
    Master_Dungeon.debug("Second room : x :" + roomTest2.x + ", y :" + roomTest2.y + " , width :" + roomTest2.width + ", height : " + roomTest2.height);
    if (roomTest1.y - 1 + roomTest1.height - 1 == roomTest2.y){
      Master_Dungeon.debug("Neighbour from first on Y");
      if(roomTest1.x + roomTest1.width - 2 >= roomTest2.x && roomTest1.x + roomTest1.width - 1 >= roomTest2.x)
      {
        Master_Dungeon.debug("Neighbour confirmed by first");
      }
    }
    else if(roomTest2.y + roomTest2.height - 1 == roomTest1.y)
    {
      Master_Dungeon.debug("Neighbour from second on Y");
      if (roomTest2.x + roomTest2.width - 1 < roomTest1.x)
      {
        Master_Dungeon.debug("Neighbour confirmed by second");
      }
    }

    /*    foreach(Room room in list_room)
        {
          Master_Dungeon.debug("room.x ==" + room.x);
          foreach (Room neighbour_room in list_room)
          {
            if (neighbour_room != room)
              ;
            Master_Dungeon.debug("neighbour_room.x == " + neighbour_room.x);
            Master_Dungeon.debug("room.x - neighbour_room.width == " + (room.x - neighbour_room.width));
            if (room.x - neighbour_room.width == neighbour_room.x)
            {
              Master_Dungeon.debug(neighbour_room.x);
            }
          }
        }*/
  }

  public void phase_end()
  {

  }

  public void view()
  {

  }

  public Web data_out()
  {
    return new Web();
  }

  public void kill()
  {

  }
}
