internal class Program
    {
        public static int win = 0;
        public static string Vorschaustein = "   @@@   \n @@@@@@@ \n @@@@@@@ \n   @@@   ";
        public static string[] Stein =
       {
            "  ▓▓▓▓▓  ",
            "▓▓▓▓▓▓▓▓▓",
            "▓▓▓▓▓▓▓▓▓",
            "  ▓▓▓▓▓  "
        };
        public static bool gameover = false;
        public static int rundenzähler = 0;
        public static int[,] matrix = {
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 }
        };

        public static int[] temp = { 0, 0 };
        //Logo Funktion
        public static void logo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n  ██╗░░░██╗██╗███████╗██████╗░  ░██████╗░███████╗░██╗░░░░░░░██╗██╗███╗░░██╗███╗░░██╗████████╗\r\n  ██║░░░██║██║██╔════╝██╔══██╗  ██╔════╝░██╔════╝░██║░░██╗░░██║██║████╗░██║████╗░██║╚══██╔══╝\r\n  ╚██╗░██╔╝██║█████╗░░██████╔╝  ██║░░██╗░█████╗░░░╚██╗████╗██╔╝██║██╔██╗██║██╔██╗██║░░░██║░░░\r\n  ░╚████╔╝░██║██╔══╝░░██╔══██╗  ██║░░╚██╗██╔══╝░░░░████╔═████║░██║██║╚████║██║╚████║░░░██║░░░\r\n  ░░╚██╔╝░░██║███████╗██║░░██║  ╚██████╔╝███████╗░░╚██╔╝░╚██╔╝░██║██║░╚███║██║░╚███║░░░██║░░░\r\n  ░░░╚═╝░░░╚═╝╚══════╝╚═╝░░╚═╝  ░╚═════╝░╚══════╝░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚══╝░░░╚═╝░░░");
            Console.ResetColor();
            Console.WriteLine("\n\n");
        }
        public static void matrixreset()
        {
            for (int i = 0; i < matrix.GetLength(0); i++) //anzahl an zeilen
            {
                for (int j = 0; j < matrix.GetLength(1); j++) //anzahl an spalten
                {
                    matrix[i, j] = 0;
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.SetWindowSize(95, 40);
            Console.SetWindowPosition(0, 0);
            Console.Title = "Vier Gewinnt";

            Computer();

            //drawmenu();


        }

        public static void drawmenu()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.SetWindowSize(95, 40);
            Console.SetWindowPosition(0, 0);
            Console.SetCursorPosition(0, 0);

            Console.Title = "Vier Gewinnt";
            int auswahl = 0;
            ConsoleKeyInfo decide;
            bool ausgewählt = false; bool zurück = false;
            string[] hauptmenü = { "> >     Spielen    < <", "> >    Optionen    < <", "> >      Exit      < <" };
            Console.CursorVisible = false;
            logo();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 0);
            //Control element
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(43, 26);
            Console.Write("<   >");
            Console.SetCursorPosition(45, 25);
            Console.Write("^");
            Console.SetCursorPosition(45, 27);
            Console.Write("v");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(45, 26);
            Console.Write("+");
            Console.SetCursorPosition(44, 23);
            Console.Write("Hoch");
            Console.SetCursorPosition(43, 29);
            Console.Write("Runter");


            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(15, 26);
            Console.Write("Zurück");
            Console.SetCursorPosition(14, 28);
            Console.Write("Backspace");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(65, 26);
            Console.Write("Weiter");
            Console.SetCursorPosition(65, 28);
            Console.Write("Enter");

            while (!ausgewählt && !zurück)
            {

                for (int i = 0; i < hauptmenü.Length; i++)  //Schleife um die Aktuelle Option Farbig zu Markieren und anzuzeigen
                {
                    string aktuellauswahl = hauptmenü[i];

                    if (i == auswahl)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Magenta;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.SetCursorPosition(35, 15 + i);
                    Console.WriteLine("{0}", aktuellauswahl);
                    Console.SetCursorPosition(0, 0);
                }
                Console.ResetColor();

                decide = Console.ReadKey(true);         //Eingabe einlesen
                if (decide.Key == ConsoleKey.UpArrow)
                {
                    auswahl--;
                    if (auswahl == -1)
                        auswahl = hauptmenü.Length - 1;
                }
                else if (decide.Key == ConsoleKey.DownArrow)
                {
                    auswahl++;
                    if (auswahl == hauptmenü.Length)
                        auswahl = 0;
                }
                else if (decide.Key == ConsoleKey.Enter || decide.Key == ConsoleKey.RightArrow)
                {
                    ausgewählt = true;
                }


            }

            if (auswahl == 0) spielmenü();
            if (auswahl == 1) Optionen();
            if (auswahl == 2) Environment.Exit(0);
        }

        public static void spielmenü()
        {
            int auswahl = 0; ConsoleKeyInfo decide; bool ausgewählt = false;
            string[] spielen = { "> >      1vs1      < <", "> >    Computer    < <", "> >      Exit      < <", "> >     Testing    < <" };

            while (!ausgewählt)
            {
                for (int i = 0; i < spielen.Length; i++)  //Schleife um die Aktuelle Option Farbig zu Markieren und anzuzeigen
                {
                    string aktuellauswahl = spielen[i];

                    if (i == auswahl)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Magenta;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.SetCursorPosition(35, 15 + i);
                    Console.WriteLine("{0}", aktuellauswahl);
                    Console.SetCursorPosition(0, 0);
                }
                Console.ResetColor();

                decide = Console.ReadKey(true);         //Eingabe einlesen
                if (decide.Key == ConsoleKey.UpArrow)
                {
                    auswahl--;
                    if (auswahl == -1)
                        auswahl = spielen.Length - 1;
                }
                else if (decide.Key == ConsoleKey.DownArrow)
                {
                    auswahl++;
                    if (auswahl == spielen.Length)
                        auswahl = 0;
                }
                else if (decide.Key == ConsoleKey.Enter || decide.Key == ConsoleKey.RightArrow)
                {
                    ausgewählt = true;
                }
                else if (decide.Key == ConsoleKey.Backspace || decide.Key == ConsoleKey.LeftArrow)
                {
                    Console.Clear();
                    drawmenu();
                }

            }

            Console.CursorVisible = true;

            if (auswahl == 0)
                Lokal();
            else if (auswahl == 1)
                Computer();
            else if (auswahl == 2)
                Environment.Exit(0);
            else if (auswahl == 3)
                Comp_test();
        }

        public static void Optionen()
        {
            Console.Clear();
            ConsoleSpinner spinner = new ConsoleSpinner();
            spinner.Delay = 300;
            while (true)
            {
                spinner.Turn(displayMsg: "Working ", sequenceCode: 4);
            }
        } //lol
        public class ConsoleSpinner
        {
            static string[,] sequence = null;

            public int Delay { get; set; } = 200;

            int totalSequences = 0;
            int counter;

            public ConsoleSpinner()
            {
                counter = 2;
                sequence = new string[,] {
                { "/", "-", "\\", "|" },
                { ".", "o", "0", "o" },
                { "+", "x","+","x" },
                { "V", "<", "^", ">" },
                { ".   ", "..  ", "... ", "...." },
                { "=>   ", "==>  ", "===> ", "====>" },
               // ADD YOUR OWN CREATIVE SEQUENCE HERE IF YOU LIKE
            };

                totalSequences = sequence.GetLength(0);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sequenceCode"> 0 | 1 | 2 |3 | 4 | 5 </param>
            public void Turn(string displayMsg = "", int sequenceCode = 0)
            {
                counter++;

                Thread.Sleep(Delay);

                sequenceCode = sequenceCode > totalSequences - 1 ? 0 : sequenceCode;

                int counterValue = counter % 4;

                string fullMessage = displayMsg + sequence[sequenceCode, counterValue];
                int msglength = fullMessage.Length;

                Console.Write(fullMessage);

                Console.SetCursorPosition(Console.CursorLeft - msglength, Console.CursorTop);
            }


        }
        //lol ende
        public static void Lokal()
        {
            Console.Clear();
            ConsoleKeyInfo key;
            string n1, n2;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Das ist lokal\n");
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Pfeiftaste Links oder Backspace um zurück ins Menü zu gelangen.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 5);
            Console.Write("Spieler 1 Namen eingeben: ");
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
                logo();
                spielmenü();
                drawmenu();
            }
            n1 = Console.ReadLine();
            Console.SetCursorPosition(0, 6);
            Console.Write("\nSpieler 2 Namen eingeben: ");
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
                logo();
                spielmenü();
                drawmenu();


            }
            n2 = Console.ReadLine();
            Console.WriteLine(n1 + " VS " + n2);
            Console.Clear();
            board();
            while (!gameover)
            {

                spieler1(1);

                if (win == 1)
                {

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(0, 33);
                    Console.WriteLine("Spieler {0} hat das Spiel gewonnen!!!", n1);
                    Console.ResetColor();
                    Thread.Sleep(3000);
                    Console.WriteLine("\nBeliebige Taste zum Fortfahren drücken...");
                    Console.SetCursorPosition(0, 0);
                    Console.ReadKey();
                    gameover = true;
                }
                rundenzähler++;
                if (!gameover)
                {
                    spieler1(-1);

                    if (win == 1)
                    {

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.SetCursorPosition(0, 33);
                        Console.WriteLine("Spieler {0} hat das Spiel gewonnen!!!", n2);
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        Console.WriteLine("\nBeliebige Taste zum Fortfahren drücken...");
                        Console.SetCursorPosition(0, 0);

                        Console.ReadKey();
                        gameover = true;
                    }
                }
                rundenzähler++;
                if (rundenzähler == 42) gameover = true;
            }

        }
        public static int current_player = 0;
        public static int wurf = 3; //ist das selbe wie Auswahl beim Spieler aber halt beim Bot
        public static int auswahl = 3; //damit die vorschau immer dort anfängt wo sie aufgehört hat, davor wurde sie immer reseted
        public static void spieler1(int spieler)
        {
            int checker = 0; bool platziert = false; ConsoleKeyInfo decide; int x = 6; int y = 3;

            while (!platziert)
            {
                if (0 == auswahl)
                {
                    x = 6;
                    y = getY(auswahl, spieler);
                    if (spieler == 1) Console.ForegroundColor = ConsoleColor.Yellow;
                    if (spieler == 2) Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("   @@@   ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("   @@@   ");
                }
                else if (1 == auswahl)
                {
                    x = 16;
                    y = getY(auswahl, spieler);
                    if (spieler == 1) Console.ForegroundColor = ConsoleColor.Yellow;
                    if (spieler == 2) Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("   @@@   ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("   @@@   ");
                }
                else if (2 == auswahl)
                {
                    x = 26;
                    y = getY(auswahl, spieler);
                    if (spieler == 1) Console.ForegroundColor = ConsoleColor.Yellow;
                    if (spieler == 2) Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("   @@@   ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("   @@@   ");
                }
                else if (3 == auswahl)
                {
                    x = 36;
                    y = getY(auswahl, spieler);
                    if (spieler == 1) Console.ForegroundColor = ConsoleColor.Yellow;
                    if (spieler == 2) Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("   @@@   ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("   @@@   ");
                }
                else if (4 == auswahl)
                {
                    x = 46;
                    y = getY(auswahl, spieler);
                    if (spieler == 1) Console.ForegroundColor = ConsoleColor.Yellow;
                    if (spieler == 2) Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("   @@@   ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("   @@@   ");
                }
                else if (5 == auswahl)
                {
                    x = 56;
                    y = getY(auswahl, spieler);
                    if (spieler == 1) Console.ForegroundColor = ConsoleColor.Yellow;
                    if (spieler == 2) Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("   @@@   ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("   @@@   ");
                }
                else if (6 == auswahl)
                {
                    x = 66;
                    y = getY(auswahl, spieler);
                    if (spieler == 1) Console.ForegroundColor = ConsoleColor.Yellow;
                    if (spieler == 2) Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("   @@@   ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine(" @@@@@@@ ");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("   @@@   ");

                }

                decide = Console.ReadKey(true);         //Eingabe einlesen
                if (decide.Key == ConsoleKey.LeftArrow)
                {
                    clearPiece(x, y);
                    auswahl--;
                    if (auswahl == -1)
                        auswahl = 6;
                    while (matrix[0, auswahl] != 0)
                    {
                        auswahl--;
                        if (auswahl == -1)
                            auswahl = 6;
                    }
                }
                else if (decide.Key == ConsoleKey.RightArrow)
                {
                    clearPiece(x, y);
                    auswahl++;
                    if (auswahl == 7)
                    {
                        auswahl = 0;
                    }
                    while (matrix[0, auswahl] != 0)
                    {
                        auswahl++;
                        if (auswahl == 7)
                        {
                            auswahl = 0;
                        }
                    }
                }
                else if (decide.Key == ConsoleKey.Enter)
                {

                    platziert = true;                     //funktion machen um den Stein in matrix[zeile, spalte] zu speichern
                    steinrein(auswahl, spieler);

                }
            }
        }
        public static void steinrein(int x, int spieler)
        {
            int i; int y = 0; bool oben = false; int xtemp = x;
            for (i = 5; i >= 0; i--) // einsetzen der Steine von Unten nach oben deshalb for-schleife rückwärts
            {
                if (matrix[i, x] == 0) //[1,2] 1 ist row 2 ist spalte
                {
                    matrix[i, x] = spieler;
                    temp[0] = x;                            //Temp 0 ist die X koordinate 
                    temp[1] = i;                            //Temp 1 ist die Y koordinate
                    if (i == 0 && spieler == 1)
                    {
                        x = 6 + (10 * x);
                        y = 3;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("  ▓▓▓▓▓  ");
                        Console.SetCursorPosition(x, y + 1);
                        Console.WriteLine("▓▓▓▓▓▓▓▓▓");
                        Console.SetCursorPosition(x, y + 2);
                        Console.WriteLine("▓▓▓▓▓▓▓▓▓");
                        Console.SetCursorPosition(x, y + 3);
                        Console.WriteLine("  ▓▓▓▓▓  ");
                        Console.ResetColor();
                        if (auswahl == 7)
                        {
                            auswahl = 0;
                        }
                        while (matrix[0, auswahl] != 0)
                        {
                            auswahl++;
                            if (auswahl == 7)
                            {
                                auswahl = 0;
                            }
                        }
                        wurf++;
                        oben = true;

                    }
                    if (i == 0 && spieler == -1)
                    {
                        x = 6 + (10 * x);
                        y = 3;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("  ▓▓▓▓▓  ");
                        Console.SetCursorPosition(x, y + 1);
                        Console.WriteLine("▓▓▓▓▓▓▓▓▓");
                        Console.SetCursorPosition(x, y + 2);
                        Console.WriteLine("▓▓▓▓▓▓▓▓▓");
                        Console.SetCursorPosition(x, y + 3);
                        Console.WriteLine("  ▓▓▓▓▓  ");
                        Console.ResetColor();
                        if (auswahl == 7)
                        {
                            auswahl = 0;
                        }
                        while (matrix[0, auswahl] != 0)
                        {
                            auswahl++;
                            if (auswahl == 7)
                            {
                                auswahl = 0;
                            }
                        }
                        wurf++;
                        oben = true;
                    }
                    break;         //wenn i also bei 3 ist ist er in der 4. Reihe von oben 28 - (5*3) = 13 der Stein wird bei [y, x] dann gemalt
                }

            }

            //wenn es ganz oben ist soll er 

            //weil der Vorschaustein -5 (also etwas höher ist) muss man wieder runter gehen


            //+5, weil er sonst eins über dem Vorschaustein malt, er soll aber über den Vorschaustein malen
            // 6 ist der wert ganz links + wie weit nach rechts es schon gegangen ist bei x = 3 (4. Spalte von links) 6 + 10*3 = 36 = Mitte vom Spielfeld
            //das ist die Zahl y auf dem Board, nicht in der Matrix
            if (!oben) //wenn es oben noch nicht platziert wurde
            {
                y = getY(x, spieler) + 5;
                x = 6 + (10 * x);
                if (spieler == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("  ▓▓▓▓▓  ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("▓▓▓▓▓▓▓▓▓");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("▓▓▓▓▓▓▓▓▓");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("  ▓▓▓▓▓  ");
                    Console.ResetColor();
                }
                if (spieler == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("  ▓▓▓▓▓  ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("▓▓▓▓▓▓▓▓▓");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("▓▓▓▓▓▓▓▓▓");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("  ▓▓▓▓▓  ");
                    Console.ResetColor();
                }
            }

        }
        public static int getY(int x, int spieler)
        {
            int y = 3;
            for (int i = 5; i >= 0; i--) // einsetzen der Steine von Unten nach oben deshalb for-schleife rückwärts
            {
                if (matrix[i, x] == 0) //[1,2] 1 ist row 2 ist spalte
                {
                    y = y + (5 * i); //y ist gleich 5 mal wie weit hoch er gegangen ist, bis er einen freien platz gefunden hat

                    checkwin(x, i, spieler);
                    break;
                }

            }
            return y;
        }

        public static void clearPiece(int x, int y)
        {
            //überprüfen ob er eins darüber den Stein wegtun muss
            Console.SetCursorPosition(x, y);
            Console.WriteLine("         ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("         ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("         ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("         ");
        }

        public static void mxcopy()
        {
            int[,] mx = new int[6, 7];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    mx[i, j] = matrix[i, j];
                }
            }
        }
        public static int check(int column) //Telci
        {
            if (matrix[0, column] != 0) //überprüft ob die Oberste Reihe belegt ist
            {
                return 1;
            }
            return 0;
        }
        //Minimax
        public static int c = 0;
        public static int Minimax(int depth, int alpha, int beta, bool maximizingPlayer) //in game loop kriegen anscheinend
        {

            if (depth == 0)
            {
                return evaluate(maximizingPlayer ? 1 : -1);
            }
            Console.WriteLine(bestCol);
            mxcopy();
            int eval = 0;
            int score=0; // call the evaluation function to get the initial score
            if (maximizingPlayer)
            {
                eval = evaluate(1);
                int bestScore = int.MinValue / 2; // initialize bestScore to a very low value
                for (int column = 0; column < 7; column++)
                {
                    for (int row = 5; row >= 0; row--)
                    {
                        if (mx[row, column] != 0)
                        {
                            continue;
                        }
                        mx[row, column] = 1; // make the move
                        if (depth > 0)
                        {
                            score = Minimax(depth - 1, alpha, beta, !maximizingPlayer);
                        }
                         // recursively call Minimax with the next depth
                        score = score + eval;
                        mx[row, column] = 0; // undo the move
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestRow = row;
                            bestCol = column;
                        }
                        alpha = Math.Max(alpha, score);
                        if (beta <= alpha)
                        {
                            break; // beta pruning
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                eval = evaluate(-1);
                int bestScore = int.MaxValue / 2; // initialize bestScore to a very high value
                for (int column = 0; column < 7; column++)
                {
                    for (int row = 5; row >= 0; row--)
                    {
                        if (mx[row, column] != 0)
                        {
                            continue;
                        }
                        mx[row, column] = -1; // make the move
                        if (depth > 0)
                        {
                            score = Minimax(depth - 1, alpha, beta, !maximizingPlayer);
                        }
                        mx[row, column] = 0; // undo the move
                        score = score + eval;
                        if (score < bestScore)
                        {
                            bestScore = score;
                            bestRow = row;
                            bestCol = column;
                        }
                        bestScore = Math.Min(bestScore, score); // update the best score
                        beta = Math.Min(beta, score);
                        if (beta <= alpha)
                        {
                            break; // alpha pruning
                        }
                    }
                }

                return bestScore;
            }

        }

        /*
         * Überprüfen ob die aktuelle position am besten ist, wenn ja Stein reinsetzen und neu evaluaten
         * für die Nächste depth
         */
        public static int[,] mx = new int[6, 7];
        public static void mxreset()
        {
            for (int i = 0; i < matrix.GetLength(0); i++) //anzahl an zeilen
            {
                for (int j = 0; j < matrix.GetLength(1); j++) //anzahl an spalten
                {
                    mx[i, j] = 0;
                }
            }
        }

        public static int bestRow = 0;
        public static int bestCol = 0;


        //diese funktion gibt nur Punkte für den aktuellen Status des Spieles, es ist NICHT der minimax algorithmus selbst
        public static int evaluate(int player) //Warrior blood must truly run in thy veins, tarnished
        {
            //-1 is minimizing player 1 maximizing
            //wenn bot gewonnen hat = -100
            //wenn spieler gewonnen hat = 100
            //wenn draw = 0

            int score = 0;
            if (CheckWin(1)) // maximizing player has won
            {
                return score = 1000;
            }
            else if (CheckWin(-1)) // minimizing player has won
            {
                return score = -1000;
            }


            // Zeilen überprüfen
            for (int row = 0; row < 6; row++) //für alles die Verbindungen überprüfen, wenn die Position mit einer anderen Verbunden ist geht der Score hoch
            {
                for (int col = 0; col < 4; col++)
                {
                    int count = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (mx[row, col + i] == player) //Wenn die Position gut ist soll er den Score +1 machen
                        {
                            count++;
                        }
                        else if (mx[row, col + i] != 0) //wenn nicht dann halt nicht, bzw eins abziehen
                        {
                            count--;
                        }
                    }
                    score += count;
                }
            }
            // Spalten überprüfen
            for (int col = 0; col < 7; col++) //col = 0
            {
                for (int row = 0; row < 3; row++) // row = 0
                {
                    int count = 0;
                    for (int i = 0; i < 4; i++) // i = 0
                    {
                        if (mx[row + i, col] == player)
                        {
                            count++;
                        }
                        else if (mx[row + i, col] != 0)
                        {
                            count--;
                        }
                    }
                    score += count;
                }
            }
            // Diagonale Positionen überprüfe
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int count = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (mx[row + i, col + i] == player)
                        {
                            count++;
                        }
                        else if (mx[row + i, col + i] != 0)
                        {
                            count--;
                        }
                    }
                    score += count;
                }
            }
            for (int row = 3; row < 6; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int count = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (mx[row - i, col + i] == player)
                        {
                            count++;
                        }
                        else if (mx[row - i, col + i] != 0)
                        {
                            count--;
                        }
                    }
                    score += count;
                }
            }
            // Find the best move
            // Möglicher Code, den wir noch brauchen werden. Was dieser Code tut weiß ich schon wieder selber nicht
            // ---------------------------------------------------------------------------------------------
            //
            //int maxScore = int.MinValue; //besten move finden
            //for (int row = 0; row < 6; row++)
            //{
            //    for (int col = 0; col < 7; col++)
            //    {
            //        if (mx[row, col] == 0)
            //        {
            //            mx[row, col] = -1;
            //            Console.Clear();
            //            for (int i = 0; i < mx.GetLength(0); i++)
            //            {
            //                for (int j = 0; j < mx.GetLength(1); j++)
            //                {
            //                    Console.Write(mx[i, j] + " ");
            //                }
            //                Console.WriteLine();
            //            }
            //            Console.WriteLine(depth + " steinrein");
            //            Console.ReadKey();
            //            int moveScore = evaluate(true, depth-1);
            //            if (moveScore > maxScore)
            //            {
            //                maxScore = moveScore;
            //                bestRow = row;
            //                bestCol = col;
            //            }
            //        }
            //    }
            //}
            // ---------------------------------------------------------------------------------------------
            if (player == -1) score = -score; //Wenn es der minimierende player war soll natürlich der kleinste score möglich sein
            return score; //jetzt die Row und Col einsetzen und es neu evaluaten lassen
        }

        public static int counter = 0;
        public static void Computer() //Oliver
        {
            Console.Clear(); ConsoleKeyInfo schwierigkeitsgrad;
            string n1; bool gameover = false; int skg = 0;
            Console.WriteLine("Spiel gegen Computer!\n\n");
            //do
            //{
            Console.WriteLine("Wähle deinen Schwierigkeitsgrad!\n[0] Leicht\n[1] Mittel\n[2] schwer\n[3] Unfair");
            //if (schwierigkeitsgrad.Key == ConsoleKey.D0) skg = 0;
            //if (schwierigkeitsgrad.Key == ConsoleKey.D1) skg = 1;
            //if (schwierigkeitsgrad.Key == ConsoleKey.D2) skg = 2;
            //if (schwierigkeitsgrad.Key == ConsoleKey.D3) skg = 3;
            //if (schwierigkeitsgrad.Key != ConsoleKey.D0 || schwierigkeitsgrad.Key != ConsoleKey.D1 || schwierigkeitsgrad.Key != ConsoleKey.D2 || schwierigkeitsgrad.Key != ConsoleKey.D3)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Ungültige Eingabe!\nNeue Eingabe in 3");
            //    Thread.Sleep(1000);
            //    Console.Clear();
            //    Console.WriteLine("Ungültige Eingabe!\nNeue Eingabe in 2");
            //    Thread.Sleep(1000);
            //    Console.Clear();
            //    Console.WriteLine("Ungültige Eingabe!\nNeue Eingabe in 1");
            //    Thread.Sleep(1000);
            //    Console.Clear();
            //}
            //} while (skg != 0 && skg != 1 && skg != 2 && skg != 3);
            Console.Clear();
            skg = -1;
            Console.WriteLine("Gewählter schwierigkeitsgrad: " + skg);
            Console.WriteLine("Gib deinen Namen ein: ");
            n1 = Console.ReadLine();
            Console.Clear();
            board();
            while (!gameover)
            {
                spieler1(1);

                if (win == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Spieler {0} hat das Spiel gewonnen!!!", n1);
                    Console.ResetColor();
                    Thread.Sleep(3000);
                    Console.WriteLine("\nBeliebige Taste zum Fortfahren drücken...");
                    Console.ReadKey();
                    gameover = true;
                }
                rundenzähler++;
                if (!gameover)
                {
                    //Comp_einwurf(skg); for testing issues wird hier direkt Minimax aufgerufen
                    Minimax(6, -100, 100, true); //Maximizing Player ist der Bot minimizing der Bot gegen sich selbst?
                                                 //     (depth, alpha, beta, maximizingplayer)
                    Console.WriteLine(bestCol + " Column amk");
                    steinrein(bestCol, -1);
                    if (win == 1)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Der Computer hat das Spiel gewonnen!");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        Console.WriteLine("\nBeliebige Taste zum Fortfahren drücken...");
                        Console.ReadKey();
                        gameover = true;
                    }
                }
                rundenzähler++;
                if (rundenzähler == 41)
                {
                    Console.Clear();
                }
            }

        }

        static int SC = 0;
        static int GC = 0;
        public static void Comp_test()
        {

            Console.Clear(); ConsoleKeyInfo schwierigkeitsgrad;
            bool gameover = false; int skg = 0;
            Console.WriteLine("Wähle deinen Schwierigkeitsgrad!\n[0] Leicht\n[1] Mittel\n[2] schwer\n[3] Unfair");
            schwierigkeitsgrad = Console.ReadKey();
            if (schwierigkeitsgrad.Key == ConsoleKey.D0) skg = 0;
            if (schwierigkeitsgrad.Key == ConsoleKey.D1) skg = 1;
            if (schwierigkeitsgrad.Key == ConsoleKey.D2) skg = 2;
            if (schwierigkeitsgrad.Key == ConsoleKey.D3) skg = 3;
            //if (schwierigkeitsgrad.Key != ConsoleKey.D0 || schwierigkeitsgrad.Key != ConsoleKey.D1 || schwierigkeitsgrad.Key != ConsoleKey.D2 || schwierigkeitsgrad.Key != ConsoleKey.D3)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Ungültige Eingabe!\nNeue Eingabe in 3");
            //    Thread.Sleep(1000);
            //    Console.Clear();
            //    Console.WriteLine("Ungültige Eingabe!\nNeue Eingabe in 2");
            //    Thread.Sleep(1000);
            //    Console.Clear();
            //    Console.WriteLine("Ungültige Eingabe!\nNeue Eingabe in 1");
            //    Thread.Sleep(1000);
            //    Console.Clear();
            //}
            //} while (skg != 0 && skg != 1 && skg != 2 && skg != 3);
            Random rnd = new Random(); int wurf; int i = 0;
            while (!gameover)
            {
                Console.Title = "SC: " + SC + "GC: " + GC;
                win = 0;
                wurf = rnd.Next(0, 6);    //               COMP TEST
                for (i = 5; i >= 0; i--) //For loop zum einsetzen des Steines
                {
                    if (matrix[i, wurf] == 0)
                    {
                        matrix[i, wurf] = 1;
                        break;
                    }
                }

                checkwin(wurf, i, 2);
                if (win == 1)
                {
                    matrixreset();
                    SC++;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Spieler scheißcomputer hat das Spiel gewonnen!!!");
                    board();
                }
                rundenzähler++;
                if (!gameover)
                {
                    Comp_einwurf(skg);
                    if (win == 1)
                    {
                        matrixreset();
                        GC++;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Der Computer hat das Spiel gewonnen!");
                        board();
                    }
                }
            }
        }

        private static bool CheckWin(int player)
        {
            // Check horizontal
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (mx[row, col] == player && mx[row, col + 1] == player && mx[row, col + 2] == player && mx[row, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check vertical
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (mx[row, col] == player && mx[row + 1, col] == player && mx[row + 2, col] == player && mx[row + 3, col] == player)
                    {
                        return true;
                    }
                }
            }

            // Check diagonal (left to right)
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (mx[row, col] == player && mx[row + 1, col + 1] == player && mx[row + 2, col + 2] == player && mx[row + 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check diagonal (right to left)
            for (int row = 0; row < 3; row++)
            {
                for (int col = 3; col < 7; col++)
                {
                    if (mx[row, col] == player && mx[row + 1, col - 1] == player && mx[row + 2, col - 2] == player && mx[row + 3, col - 3] == player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static void Comp_einwurf(int skg) //[1,2] row 1 und column 2 Oliver if-Simulator
        {
            int t = 0; int z = temp[0]; int s = temp[1]; int checker = 0;   //Computer wirft immer die Zahl 2 ein 
            Random rnd = new Random();
            //skg wird richtig gewählt
            skg = 0;
            if (skg == 0)//leicht 
            {
                Minimax(6, -100, 100, true); //Maximizing Player ist der Bot minimizing der Bot gegen sich selbst?
                //     (depth, alpha, beta, maximizingplayer)
                steinrein(bestCol, -1);
            }

            if (skg == 1)//schwierigkeitsgrad mittel
            {
                checker = 0;
                if (rundenzähler == 1)
                {
                    wurf = rnd.Next(0, 6);
                    if (matrix[5, wurf] == 1 && wurf == 0) //überprüfen ob die gewürfelte Zeile besetzt ist, falls ja und er links vom Spielfeld ist soll er nach rechts gehen
                        wurf++;
                    if (matrix[5, wurf] == 1 && wurf == 6) //Überprüfen ob die gewürfelte Zeile besetzt ist, falls ja und er rechts vom Spielfeld ist soll er nach links gehen
                        wurf--;
                    if (matrix[5, wurf] == 1) //wenn die Zeile belegt ist soll er zufällig nach rechts oder nach links gehen
                    {
                        t = rnd.Next(0, 1);
                        if (t == 1) wurf--;
                        else wurf++;
                    }
                }

                if (rundenzähler > 1)
                {
                    wurf = s;  //Wurf ist die vom Spieler eingegebene Spalte
                    if (wurf == 0) //Wenn er links ist
                    {
                        t = rnd.Next(0, 2);
                        if (t == 1) wurf++; //entweder nach rechts gehen oder ganz links bleiben
                        if (t == 2) wurf = wurf + 2; //oder 2 nach rechts gehen
                    }
                    else if (wurf == 6)//wenn er ganz rechts ist
                    {
                        t = rnd.Next(0, 2);
                        if (t == 2) wurf--; //entweder nach links gehen oder rechts bleiben
                        if (t == 1) wurf = wurf - 2; //oder 2 nach links
                    }
                    else if (wurf > 0 && 6 > wurf) //zwischen 1 und 5 ausführen
                    {
                        t = rnd.Next(0, 1);
                        if (t == 0) wurf--;//nach links
                        if (t == 1) wurf++;//oder nach rechts gehen
                    }
                    checker = check(wurf); //überprufen ob die Oberste position besetzt ist
                    if (checker == 1) //wenn ja wird die Methode neu aufgerufen und neu gewürfelt
                    {
                        while (matrix[0, wurf] != 0)
                        {
                            wurf++;
                            if (wurf == 7)
                            {
                                wurf = 0;
                            }
                        }
                    }
                }
                //wenn die Zeile belegt ist weiter nach rechts gehen
                steinrein(wurf, -1);
            }

            if (skg == 2) //schwierigkeitsgrad schwer
            {
                if (rundenzähler == 1)
                {
                    wurf = rnd.Next(0, 6);
                    if (matrix[5, wurf] == 1 && wurf == 0) //überprüfen ob die gewürfelte Zeile besetzt ist, falls ja und er links vom Spielfeld ist soll er nach rechts gehen
                        wurf++;
                    if (matrix[5, wurf] == 1 && wurf == 6) //Überprüfen ob die gewürfelte Zeile besetzt ist, falls ja und er rechts vom Spielfeld ist soll er nach links gehen
                        wurf--;
                    if (matrix[5, wurf] == 1) //wenn die Zeile belegt ist soll er zufällig nach rechts oder nach links gehen
                    {
                        t = rnd.Next(0, 1);
                        if (t == 1) wurf--;
                        else wurf++;
                        matrix[5, wurf] = 2;
                    }
                }
                if (rundenzähler > 1)
                {
                    wurf = s;  //Wurf ist die vom Spieler eingegebene Spalte

                    //[1,2] 1 ist row 2 ist column
                    for (int j = 0; j < 6; j++)
                    {
                        for (int i = 0; i < 4; i++)
                        { //horizontale reihen nach 3 stücken in einer Reihe überprüfen
                            if (matrix[j, i] == 1 && matrix[j, i + 1] == 1 && matrix[j, i + 2] == 1)
                            {
                                if (i + 3 == 0 && j == 5) matrix[j, i + 3] = 2; /*wenn i+3 also das vierte Feld von links frei ist und es in der untersten Zeile ist,
                                                                              * soll er das vierte Feld auf 2 setzen
                                                                              */
                                for (int zc = 0; zc < 4; zc++) //zc = zurückcounter
                                {
                                    if (i + zc == 0 && j == 5 && i - zc == 0) matrix[j, i - zc] = 2;
                                }
                                if (i == 1 && j == 5 && i - 1 == 0) matrix[j, i - 1] = 2;
                            }
                        }
                    }

                    if (wurf == 0) //Wenn er links ist
                    {
                        t = rnd.Next(0, 2);
                        if (t == 1) wurf++; //entweder nach rechts gehen oder ganz links bleiben
                        if (t == 2) wurf = wurf + 2; //oder 2 nach rechts gehen
                    }
                    else if (wurf == 6)//wenn er ganz rechts ist
                    {
                        t = rnd.Next(0, 2);
                        if (t == 2) wurf--; //entweder nach links gehen oder rechts bleiben
                        if (t == 1) wurf = wurf - 2; //oder 2 nach links
                    }
                    else if (wurf > 0 && 6 > wurf) //zwischen 1 und 5 ausführen
                    {
                        t = rnd.Next(0, 1);
                        if (t == 0) wurf--;//nach links
                        if (t == 1) wurf++;//oder nach rechts gehen
                    }
                    checker = check(wurf); //überprufen ob die Oberste position besetzt ist

                }

            }
            if (skg == 3)//unfair
            {
            }
        }

        public static int checkwin(int x, int y, int player)
        {

            // Überprüfen der vertikalen Linien
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int count = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col] == player)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }

                    if (count >= 4)
                    {
                        win = 1; // Spieler hat gewonnen
                    }
                }
            }

            // Überprüfen der horizontalen Linien
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int count = 0;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == player)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }

                    if (count >= 4)
                    {
                        win = 1; // Spieler hat gewonnen
                    }
                }
            }

            for (int row = matrix.GetLength(0) - 1; row >= 3; row--)
            {
                for (int col = 0; col <= matrix.GetLength(1) - 4; col++)
                {
                    if (matrix[row, col] == player &&
                        matrix[row - 1, col + 1] == player &&
                        matrix[row - 2, col + 2] == player &&
                        matrix[row - 3, col + 3] == player)
                    {
                        win = 1; // Spieler hat gewonnen
                    }
                }
            }

            // Überprüfen der diagonalen Linien von links oben nach rechts unten
            for (int row = 0; row <= matrix.GetLength(0) - 4; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - 4; col++)
                {
                    if (matrix[row, col] == player &&
                        matrix[row + 1, col + 1] == player &&
                        matrix[row + 2, col + 2] == player &&
                        matrix[row + 3, col + 3] == player)
                    {
                        win = 1; // Spieler hat gewonnen
                    }
                }
            }

            // Kein Gewinner gefunden
            return 0;
        }

        public static string[] Board =
         {
            "     ╔═════════╦═════════╦═════════╦═════════╦═════════╦═════════╦═════════╗",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ╠═════════╬═════════╬═════════╬═════════╬═════════╬═════════╬═════════╣",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ╠═════════╬═════════╬═════════╬═════════╬═════════╬═════════╬═════════╣",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ╠═════════╬═════════╬═════════╬═════════╬═════════╬═════════╬═════════╣",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ╠═════════╬═════════╬═════════╬═════════╬═════════╬═════════╬═════════╣",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ╠═════════╬═════════╬═════════╬═════════╬═════════╬═════════╬═════════╣",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "     ║         ║         ║         ║         ║         ║         ║         ║",
            "    ═╩═════════╩═════════╩═════════╩═════════╩═════════╩═════════╩═════════╩═"
        };




        public static void board()//Jamie
        {
            string board = "\n\n";

            for (int r = 0; r < 31; r++)
            {
                board += string.Format("{0}\n", Board[r]); /*board ist eine Variable des Spielfeldes 
                                                            * mit dem For loop werden alle Zeilen der Variable board angefügt, dadurch kann das Board neu generiert werden
                                                            */

            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(board);
            Console.ResetColor();

        }



    }
