using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IplCensorshipAnalyzer
{
    // Model for IPL Match
    public class IplMatchRecord
    {
        public int match_id { get; set; }
        public string team1 { get; set; }
        public string team2 { get; set; }
        public Dictionary<string, int> score { get; set; }
        public string winner { get; set; }
        public string player_of_match { get; set; }
    }

    // Utility class for masking rules
    public static class CensorshipUtility
    {
        public static string MaskTeamName(string teamName)
        {
            if (string.IsNullOrWhiteSpace(teamName)) return teamName;

            string[] parts = teamName.Split(' ');
            if (parts.Length == 1)
                return parts[0] + " ***";

            parts[1] = "***";
            return string.Join(" ", parts);
        }
    }

    // JSON Processor
    public class JsonIplProcessor
    {
        public static List<IplMatchRecord> ReadJson(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<IplMatchRecord>>(json);
        }

        public static void WriteJson(string path, List<IplMatchRecord> matches)
        {
            string output = JsonConvert.SerializeObject(matches, Formatting.Indented);
            File.WriteAllText(path, output);
        }

        public static void ApplyCensorship(List<IplMatchRecord> matches)
        {
            foreach (var match in matches)
            {
                string maskedTeam1 = CensorshipUtility.MaskTeamName(match.team1);
                string maskedTeam2 = CensorshipUtility.MaskTeamName(match.team2);

                var updatedScore = new Dictionary<string, int>();
                foreach (var entry in match.score)
                {
                    string maskedKey = CensorshipUtility.MaskTeamName(entry.Key);
                    updatedScore[maskedKey] = entry.Value;
                }

                match.team1 = maskedTeam1;
                match.team2 = maskedTeam2;
                match.score = updatedScore;
                match.winner = CensorshipUtility.MaskTeamName(match.winner);
                match.player_of_match = "REDACTED";
            }
        }
    }

    // CSV Processor
    public class CsvIplProcessor
    {
        public static List<string[]> ReadCsv(string path)
        {
            return File.ReadAllLines(path)
                       .Skip(1)
                       .Select(line => line.Split(','))
                       .ToList();
        }

        public static void WriteCsv(string path, List<string[]> rows)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("match_id,team1,team2,score_team1,score_team2,winner,player_of_match");
                foreach (var row in rows)
                {
                    writer.WriteLine(string.Join(",", row));
                }
            }
        }

        public static List<string[]> ApplyCensorship(List<string[]> rows)
        {
            var output = new List<string[]>();

            foreach (var row in rows)
            {
                row[1] = CensorshipUtility.MaskTeamName(row[1]);
                row[2] = CensorshipUtility.MaskTeamName(row[2]);
                row[5] = CensorshipUtility.MaskTeamName(row[5]);
                row[6] = "REDACTED";
                output.Add(row);
            }
            return output;
        }
    }

    // Main Program
    class ProgramEntry
    {
        static void Main()
        {
            Console.WriteLine("IPL Censorship Analyzer Started...\n");

            // JSON Processing
            var jsonMatches = JsonIplProcessor.ReadJson("ipl_input.json");
            JsonIplProcessor.ApplyCensorship(jsonMatches);
            JsonIplProcessor.WriteJson("ipl_censored.json", jsonMatches);

            // CSV Processing
            var csvRows = CsvIplProcessor.ReadCsv("ipl_input.csv");
            var censoredCsv = CsvIplProcessor.ApplyCensorship(csvRows);
            CsvIplProcessor.WriteCsv("ipl_censored.csv", censoredCsv);

            Console.WriteLine("Censorship Completed Successfully!");
        }
    }
}
