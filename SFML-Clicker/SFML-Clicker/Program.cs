using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_Clicker
{
    class Program
    {
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
        static void Main(string[] args)
        {
            RenderWindow app = new RenderWindow(new VideoMode(800,600), "Clicker");
            app.Closed += new EventHandler(OnClose);

            CircleShape circle = new CircleShape(25);
            circle.FillColor = Color.White;

            bool firstStart = true;

            int score = 0;

            while (app.IsOpen)
            {
                app.DispatchEvents();
                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                {
                    app.Close();
                }

                var mouse_pos = Mouse.GetPosition(app);
                var translated_pos = app.MapPixelToCoords(mouse_pos);

                // Mouse is inside the circle and user clicked
                if (circle.GetGlobalBounds().Contains(translated_pos.X, translated_pos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    score++;
                    Console.WriteLine(score);
                    app.Clear(Color.Black);
                    Random r = new Random();
                    float randX = r.Next(1,750);
                    float randY = r.Next(1,550);
                    circle.Position = new Vector2f(randX, randY);
                    app.Draw(circle);
                }

                if (firstStart)
                {
                    app.Clear(Color.Black);
                    circle.Position = new Vector2f(380, 250);
                    app.Draw(circle);
                    firstStart = false;
                }

                app.Display();
            }
        }
    }
}
