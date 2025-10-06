using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
    }
}
