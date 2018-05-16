using System;
using System.Collections.Generic;

public class Room {

    public int x { get; set; }
    public int y { get; set; }
    public int width { get; set; }
    public int height { get; set; }

    public Room(int horizontalPositionBottomLeftCorner, int verticalPositionBottomLeftCorner, int newWidth, int newHeight)
    {
        x = horizontalPositionBottomLeftCorner;
        y = verticalPositionBottomLeftCorner;
        width = newWidth;
        height = newHeight;
    }

}
