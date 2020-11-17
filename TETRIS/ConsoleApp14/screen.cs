using System;
using System.Collections.Generic;
using System.Text;

    
    
        class screen
        {
   static protected int X;
    static protected int Y;
  

            protected List<List<string>> list = new List<List<string>>();
            public screen(int _x, int _y,bool draw)
            {
                for (int y = 0; y < _y; y++)
                {
                    list.Add(new List<string>());
                    for (int x = 0; x < _x; x++)
                    {
                if (draw == true)
                {
                    if (y == 0 || (_y - 1) == y)
                    {
                        list[y].Add("▣");
                    }
                    else
                    {
                        list[y].Add("□");
                    }
                }
                else
                {
                    list[y].Add("□");
                }
                
                    }
                }
        X = _x;
        Y = _y;
            }
            public void draw()
            {
                for (int y = 0; y < list.Count; y++)
                {
                    for (int x = 0; x < list[y].Count; x++)
                    {
                        Console.Write(list[y][x]);
                    }
                    Console.WriteLine();

                }
            }

    public void drawblock(int _x, int _y, string _type)
    {
        list[_y][_x] = _type;
    }

    

    public void resetblock(string sblock,int y,int x)
    {

        if (sblock == "■")
        {
            list[y][x] = "□";
        }

    }
}
    

