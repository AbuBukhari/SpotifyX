using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using System.Drawing;
using Console = Colorful.Console;

namespace SpotifyX_Console.Logo
{
    class Design
    {
        public static void Logo()
        {
            Logger.Logger.Logg("Printing logo on console.");
            Console.WriteLine(@"

   _____             __  _ ____     _  __
  / ___/____  ____  / /_(_) __/_  _| |/ /
  \__ \/ __ \/ __ \/ __/ / /_/ / / /   / 
 ___/ / /_/ / /_/ / /_/ / __/ /_/ /   |  
/____/ .___/\____/\__/_/_/  \__, /_/|_|  
    /_/                    /____/        

                                                       
     [https://github.com/Vanix599]                    
                                
", Color.FromArgb(30, 215, 96));
            Console.WriteLine();
        }
    }
}
