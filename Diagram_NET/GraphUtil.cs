using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.ShortestPath;
using QuikGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram_NET
{
    public class PathEdge
    {
        public string Source { get; set; }
        public string Target { get; set; }

        public PathEdge(string source, string target)
        {
            this.Source = source;
            this.Target = target;
        }
    }

    public class PathDistanceRec
    {
        public double Dis { get; set; }
        public string Path { get; set; }
        public string StartEnd { get; set; }
        public List<string> PathList { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public List<PathEdge> PathEdges { get; set; }

    }

    public static class GraphUtil
    {
        public static List<PathDistanceRec> GetShortestPath(AdjacencyGraph<string, SEquatableTaggedEdge<string, double>> graph,
            string start, string end)
        {
            List<PathDistanceRec> pathDistanceRecs = new List<PathDistanceRec>();
            // 使用 Dijkstra 算法找到最短路径
            var algorithm = new DijkstraShortestPathAlgorithm<string, SEquatableTaggedEdge<string, double>>(graph, edge => edge.Tag);

            var predecessors = new VertexPredecessorRecorderObserver<string, SEquatableTaggedEdge<string, double>>();
            // 指定起点
            string source = start;
            using (predecessors.Attach(algorithm))
            {
                algorithm.Compute(source);
                foreach (var ver in graph.Vertices)
                {
                    if (ver != source && ver == end && algorithm.TryGetDistance(ver, out double distance))
                    {
                        List<PathEdge> pathEdges = new List<PathEdge>();
                        List<string> pathList = new List<string>();
                        PathDistanceRec pathDistanceRec = new PathDistanceRec();
                        pathDistanceRec.StartEnd = source + "->" + end;
                        pathDistanceRec.Start = source;
                        pathDistanceRec.End = end;
                        pathDistanceRec.Dis = distance;
                        IEnumerable<SEquatableTaggedEdge<string, double>> path;
                        predecessors.TryGetPath(end, out path);
                        if (path == null) return null;
                        pathDistanceRec.Path = string.Join(",", path);
                        foreach (var step in path)
                        {
                            pathList.Add(step.Source);
                            pathEdges.Add(new PathEdge(step.Source, step.Target));
                        }
                        pathList.Add(end);
                        pathDistanceRecs.Add(pathDistanceRec);
                        pathDistanceRec.PathList = pathList;
                        pathDistanceRec.PathEdges = pathEdges;
                    }
                }
            }
            return pathDistanceRecs;
        }

        public static List<PathDistanceRec> GetLongestPath(AdjacencyGraph<string, SEquatableEdge<string>> graph,
            string start, string end)
        {
            var allPaths = new List<List<string>>();
            var visited = new HashSet<string>();
            var pathList = new List<string>();
            var longestPath = new List<string>();
            double longestDistance = 0;

            // 回溯算法找到所有路径
            GetAllPaths(graph, start, end, visited, pathList, allPaths);

            // 从所有路径中找到最长的路径
            foreach (var path in allPaths)
            {
                double currentDistance = path.Count - 1; // 这里假设每条边的距离为1
                if (currentDistance > longestDistance)
                {
                    longestDistance = currentDistance;
                    longestPath = path;
                }
            }
            // 构建最长路径的记录
            var longestPathRecord = new PathDistanceRec
            {
                Start = start,
                End = end,
                Dis = longestDistance,
                PathList = longestPath,
                PathEdges = GetPathEdges(longestPath)
            };

            return new List<PathDistanceRec> { longestPathRecord };
        }

        private static void GetAllPaths(AdjacencyGraph<string, SEquatableEdge<string>> graph, string currentVertex, string endVertex, HashSet<string> visited, List<string> localPathList, List<List<string>> allPaths)
        {
            visited.Add(currentVertex);
            localPathList.Add(currentVertex);

            if (currentVertex.Equals(endVertex))
            {
                allPaths.Add(new List<string>(localPathList));
            }
            else
            {
                foreach (var edge in graph.OutEdges(currentVertex))
                {
                    if (!visited.Contains(edge.Target))
                    {
                        GetAllPaths(graph, edge.Target, endVertex, visited, localPathList, allPaths);
                    }
                }
            }

            localPathList.RemoveAt(localPathList.Count - 1);
            visited.Remove(currentVertex);
        }

        private static List<PathEdge> GetPathEdges(List<string> path)
        {
            var pathEdges = new List<PathEdge>();
            for (int i = 0; i < path.Count - 1; i++)
            {
                pathEdges.Add(new PathEdge(path[i], path[i + 1]));
            }
            return pathEdges;
        }
    }
}
