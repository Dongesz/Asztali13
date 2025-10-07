using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TerminalGame
{
    internal static class FileManager
    {
        public static void SavePlayerStats(Player player, int rounds, int wins, string fileName = "player_stats.txt")
        {
            string content =
                $"Date: {DateTime.Now}\n" +
                $"Name: {player.Name}\n" +
                $"Class: {player.GetType().Name}\n" +
                $"HP: {player.Hp}, DP: {player.Dp}, Defense: {player.Defense}\n" +
                $"Rounds Played: {rounds}, Wins: {wins}\n" +
                $"-----------------------------\n";
            File.AppendAllText(fileName, content);
        }

        public static string ReadAllStats(string fileName = "player_stats.txt")
        {
            return File.Exists(fileName) ? File.ReadAllText(fileName) : "No stats found.";
        }
        public static string GetLeaderboard(int top = 10, string fileName = "player_stats.txt")
        {
            string content = ReadAllStats(fileName);
            if (content == "No stats found.") return "";

            var blocks = content.Split(new[] { "-----------------------------\n" }, StringSplitOptions.RemoveEmptyEntries);

            var tempStats = new Dictionary<string, int>();
            foreach (var block in blocks)
            {
                var lines = block.Split('\n');
                string name = null;
                int winsValue = 0;

                foreach (var line in lines)
                {
                    if (line.StartsWith("Name: "))
                    {
                        name = line.Substring("Name: ".Length).Trim();
                    }
                    else if (line.StartsWith("Rounds Played: "))
                    {
                        var parts = line.Substring("Rounds Played: ".Length).Split(new[] { ", Wins: " }, StringSplitOptions.None);
                        if (parts.Length == 2)
                        {
                            winsValue = int.Parse(parts[1].Trim());
                        }
                    }
                }

                if (!string.IsNullOrEmpty(name))
                {
                    if (!tempStats.ContainsKey(name))
                    {
                        tempStats[name] = 0;
                    }
                    tempStats[name] += winsValue;
                }
            }

            var playerStats = new KeyValuePair<string, int>[tempStats.Count];
            int index = 0; 
            foreach (var pair in tempStats)
            {
                playerStats[index++] = new KeyValuePair<string, int>(pair.Key, pair.Value);
            }

            for (int i = 0; i < index - 1; i++)
            {
                for (int j = i + 1; j < index; j++)
                {
                    if (playerStats[i].Value < playerStats[j].Value)
                    {
                        var temp = playerStats[i];
                        playerStats[i] = playerStats[j];
                        playerStats[j] = temp;
                    }
                }
            }

            int itemsToTake = Math.Min(top, index);
            string result = "";
            for (int i = 0; i < itemsToTake; i++)
            {
                result += $"{i + 1}. {playerStats[i].Key} - {playerStats[i].Value} wins\n";
            }

            return result;
        }
    }
}

