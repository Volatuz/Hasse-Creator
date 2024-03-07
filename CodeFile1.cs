/*using System;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    static void Main()
    {
        int nivel = 4; // Nivel de profundidad del diagrama de Hasse (puedes ajustarlo según tus necesidades)
        int ancho = 800; // Ancho de la imagen en píxeles
        int alto = 800; // Alto de la imagen en píxeles

        using (Bitmap imagen = new Bitmap(ancho, alto))
        using (Graphics graficos = Graphics.FromImage(imagen))
        {
            graficos.Clear(Color.White);

            int espacioHorizontal = ancho / (nivel + 1);

            DibujarNodos(graficos, espacioHorizontal, nivel, ancho / 2, 50, 0);

            imagen.Save("DiagramaHasse.png", ImageFormat.Png);
        }

        Console.WriteLine("Diagrama de Hasse exportado como DiagramaHasse.png");
    }

    static void DibujarNodos(Graphics graficos, int espacio, int nivel, int x, int y, int profundidad)
    {
        if (profundidad > nivel)
            return;

        int radio = 20;

        graficos.FillEllipse(Brushes.Blue, x - radio, y - radio, 2 * radio, 2 * radio);

        DibujarNodos(graficos, espacio, nivel, x - espacio, y + 100, profundidad + 1);
        DibujarNodos(graficos, espacio, nivel, x + espacio, y + 100, profundidad + 1);
    }
}
*/