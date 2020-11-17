using System;
using System.Collections.Generic;




class Program
{




    static void Main(string[] args)
    {
        
     




        
        screen screen = new screen(10,15,true);
        Bscreen bscreen = new Bscreen(screen);
        Block block = new Block(screen,Block.blocktype.I,Block.Blockdic.L,bscreen);
      
        while (true)
        {
            for (int i = 0; i < 100000000; i++)
            {

            }

            Console.Clear();
           
            screen.draw();
            bscreen.Bdraw();
            block.move();
            block.ground();
           
            bscreen.breakline();
        }
      


    }
        }
    

