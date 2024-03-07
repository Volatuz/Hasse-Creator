using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Types.Attributes;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Orientation;
using GiGraph.Dot.Types.Rankdir;

namespace HasseDiagram
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new DotGraph();

            graph.Attributes.Orientation = DotOrientation.Landscape;
            graph.Attributes.RankDirection = DotRankDirection.LeftToRight;

            int n = 5; // Cambia el valor de "n" según la cantidad de números binarios que desees representar.

            for (int i = 0; i < (1 << n); i++)
            {
                var binaryString = Convert.ToString(i, 2).PadLeft(n, '0');

                var node = new DotNode(binaryString);
                node.Attributes.Shape = DotNodeShape.Circle;
                node.Attributes.FontColor = DotColor.Transparent;

                graph.Nodes.Add(node);

                for (int j = 0; j < n; j++)
                {
                    if (binaryString[j] == '0')
                    {
                        var predNode = graph.Nodes.FirstOrDefault(n => n.Id == binaryString.Substring(0, j) + '1' + binaryString.Substring(j + 1));
                        if (predNode != null)
                        {
                            graph.Edges.Add(node, predNode);
                        }
                    }
                }
            }

            string dotContent = graph.Build();
            File.WriteAllText("HasseDiagram.dot", dotContent);

            // Ejecutar Graphviz para convertir el archivo DOT en una imagen PNG
            var dotPath = "dot.exe"; // Cambia esto según la ubicación de dot.exe en tu sistema
            var outputImagePath = "HasseDiagram.png";
            var processStartInfo = new ProcessStartInfo(dotPath, $"-Tpng HasseDiagram.dot -o {outputImagePath}");
            Process.Start(processStartInfo);

            Console.WriteLine("Diagrama de Hasse creado como HasseDiagram.png");
        }
    }
}
