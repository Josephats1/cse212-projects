using System;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Recursive Squares Sum
    /// Calculates the sum of squares from 1^2 to n^2 using recursion
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Permutations Choose
    /// Generates all permutations of given size from a list of unique letters
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        foreach (char c in letters)
        {
            if (!word.Contains(c.ToString()))
            {
                PermutationsChoose(results, letters, size, word + c);
            }
        }
    }

    /// <summary>
    /// Problem 3: Climbing Stairs
    /// Counts the number of ways to climb stairs taking 1, 2, or 3 steps at a time
    /// Uses memoization for efficiency with larger inputs
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) + 
                       CountWaysToClimb(s - 2, remember) + 
                       CountWaysToClimb(s - 3, remember);
        
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Wildcard Binary Patterns
    /// Generates all possible binary strings by replacing wildcards (*) with 0 or 1
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int wildcardIndex = pattern.IndexOf('*');
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern[..wildcardIndex] + "0" + pattern[(wildcardIndex + 1)..], results);
        WildcardBinary(pattern[..wildcardIndex] + "1" + pattern[(wildcardIndex + 1)..], results);
    }

    /// <summary>
    /// Problem 5: Maze Solver
    /// Finds all paths from start (0,0) to end in a maze using recursion and backtracking
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        // Initialize path if first call
        if (currPath == null)
        {
            currPath = new List<(int, int)>();
        }

        // Add current position to path
        currPath.Add((x, y));

        // Check if reached the end
        if (maze.IsEnd(x, y))
        {
            results.Add(PathToString(currPath));
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Possible moves (right, down, left, up)
        int[] dx = { 1, 0, -1, 0 };
        int[] dy = { 0, 1, 0, -1 };

        for (int i = 0; i < 4; i++)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];

            if (maze.IsValidMove(newX, newY, currPath))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }

    /// <summary>
    /// Helper method to convert path to string representation
    /// </summary>
    private static string PathToString(List<(int, int)> path)
    {
        return string.Join("->", path);
    }
}

// Maze class definition (provided in original problem)
public class Maze
{
    public bool IsEnd(int x, int y) { /* implementation */ }
    public bool IsValidMove(int x, int y, List<(int, int)> path) { /* implementation */ }
}