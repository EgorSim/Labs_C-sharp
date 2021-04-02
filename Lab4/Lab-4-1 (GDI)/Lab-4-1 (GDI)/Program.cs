using System;
using System.Drawing;

namespace Lab_4_1__GDI_ {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Support such commands: fillellips, fillrectangle");
            Console.WriteLine("Support such colours: red, white");
            bool wantToDraw = true;
            do {

                bool drawed;
                do {
                    drawed = false;
                    Console.WriteLine("Enter command, for instance fillellips:red:10:10:100:200");
                    string command = Console.ReadLine();
                    command = command.Replace(" ", "");
                    command = command.ToLower();
                    string[] parsedCommand = command.Split(':');
                    if (parsedCommand[0] == "fillellips") {
                        try {
                            Color color = StringToColor(parsedCommand[1]);
                            int x = Convert.ToInt32(parsedCommand[2]);
                            int y = Convert.ToInt32(parsedCommand[3]);
                            int width = Convert.ToInt32(parsedCommand[4]);
                            int height = Convert.ToInt32(parsedCommand[5]);
                            DrawningsOnTable.FillEllips(color, x, y, width, height);
                            drawed = true;
                        }
                        catch (Exception ex) {
                            Console.WriteLine($"Can't work with such command: {ex.Message}");
                        }
                    }
                    else if (parsedCommand[0] == "fillrectangle") {
                        try {
                            Color color = StringToColor(parsedCommand[1]);
                            int x = Convert.ToInt32(parsedCommand[2]);
                            int y = Convert.ToInt32(parsedCommand[3]);
                            int width = Convert.ToInt32(parsedCommand[4]);
                            int height = Convert.ToInt32(parsedCommand[5]);
                            DrawningsOnTable.FillRectangle(color, x, y, width, height);
                            drawed = true;
                        }
                        catch (Exception ex) {
                            Console.WriteLine($"Can't work with such command: {ex.Message}");
                        }
                    }
                    else {
                        Console.WriteLine($"There is no such command {parsedCommand[0]}");
                    }
                } while (!drawed);
                Console.WriteLine("Want to continue? (hit escape to leave, any other - stay): ");
                ConsoleKeyInfo proposal = Console.ReadKey();
                if(proposal.Key == ConsoleKey.Escape) {
                    wantToDraw = false;
                }
            } while (wantToDraw);
        }
        static Color StringToColor(string colorStr) {
            Color color;
            if(colorStr == "red") {
                color = Color.Red;
            } else if(colorStr == "white") {
                color = Color.White;
            }
            else {
                throw new Exception($"Don't know such color {colorStr}");
            }
            return color;
        }
    }
}
