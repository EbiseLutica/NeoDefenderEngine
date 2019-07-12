using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DotFeather;

namespace NeoDefenderEngine
{
    public class Resources
    {
        public static Resources I { get; } = new Resources();

        public Dictionary<string, IAudioSource> Songs { get; } = new Dictionary<string, IAudioSource>();
        public Dictionary<string, IAudioSource> Sfx { get; } = new Dictionary<string, IAudioSource>();

        public string CharMapping { get; private set; }
        public string PrologFemale { get; private set; }
        public string PrologMale { get; private set; }
        public string StaffCredit { get; private set; }

        public async Task LoadAllMusic(IProgress<InitializeStatus> stat)
        {
            var songs = Directory.GetFiles("./Resources/Music");

            for (var i = 0; i < songs.Length; i++)
            {
                var key = Path.GetFileName(songs[i]);
                try
                {
                    var value = await Task.Factory.StartNew(() => new GroorineAudioSource(File.OpenRead(songs[i])));
                    Songs[key] = value;
                }
                catch (Exception ex)
                {
                    stat.Report(new InitializeStatus($"Error to load {key}: {ex.GetType().Name}: {ex.Message}", i, songs.Length));
                    continue;
                }
                stat.Report(new InitializeStatus($"Loaded: {key}", i, songs.Length));
            }
        }

        public async Task LoadAllSfx(IProgress<InitializeStatus> stat)
        {
            var sfx = Directory.GetFiles("./Resources/Sounds");

            for (var i = 0; i < sfx.Length; i++)
            {
                var key = Path.GetFileName(sfx[i]);
                try
                {
                    var value = await Task.Factory.StartNew(() => new WaveAudioSource(sfx[i]));
                    Songs[key] = value;
                }
                catch (Exception ex)
                {
                    stat.Report(new InitializeStatus($"Error to load {key}: {ex.GetType().Name}: {ex.Message}", i, sfx.Length));
                    continue;
                }
                stat.Report(new InitializeStatus($"Loaded: {key}", i, sfx.Length));
            }
        }

        public async Task LoadAllText(IProgress<InitializeStatus> stat)
        {
            CharMapping = await File.ReadAllTextAsync("./Resources/Document/char.txt");
            stat.Report(new InitializeStatus("Loaded: char.txt", 0, 4));
            CharMapping = await File.ReadAllTextAsync("./Resources/Document/prolog-female.txt");
            stat.Report(new InitializeStatus("Loaded: prolog-female.txt", 1, 4));
            CharMapping = await File.ReadAllTextAsync("./Resources/Document/prolog-male.txt");
            stat.Report(new InitializeStatus("Loaded: prolog-male.txt", 2, 4));
            CharMapping = await File.ReadAllTextAsync("./Resources/Document/staffrole.txt");
            stat.Report(new InitializeStatus("Loaded: staffrole.txt", 3, 4));
        }
    }
}