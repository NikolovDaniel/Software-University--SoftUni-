namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            //For the ExportSongsAboveDuration method, duration is in seconds

            Console.WriteLine(ExportAlbumsInfo(context, 1)); // Example with producerId = 1
            Console.WriteLine(ExportSongsAboveDuration(context, 240)); // Example with duration = 240 seconds (4 minutes)

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .ToList();


            foreach (var a in albums.OrderByDescending(a => a.Price))
            {
                sb.AppendLine($"-AlbumName: {a.Name}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate.ToString("d", DateTimeFormatInfo.InvariantInfo)}");
                sb.AppendLine($"-ProducerName: {a.Producer.Name}");
                sb.AppendLine($"-Songs:");

                int count = 1;

                foreach (var s in a.Songs.OrderByDescending(s => s.Name).ThenBy(s => s.Writer.Name))
                {
                    sb.AppendLine($"---#{count}");
                    sb.AppendLine($"---SongName: {s.Name}");
                    sb.AppendLine($"---Price: {s.Price:F2}");
                    sb.AppendLine($"---Writer: {s.Writer.Name}");

                    count++;
                }

                sb.AppendLine($"-AlbumPrice: {a.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context.Songs.ToList();

            songs = songs.Where(s => s.Duration.TotalSeconds > duration).ToList();

            int count = 1;

            foreach (var s in songs.OrderBy(s => s.Name).ThenBy(s => s.Writer.Name))
            {
                sb.AppendLine($"-Song #{count}");
                sb.AppendLine($"---SongName: {s.Name}");
                sb.AppendLine($"---Writer: {s.Writer.Name}");
                if (s.SongPerformers.Count > 0)
                {
                    foreach (var p in s.SongPerformers.OrderBy(s => s.Performer.FirstName))
                    {
                        sb.AppendLine($"---Performer: {p.Performer.FirstName + " " + p.Performer.LastName}");
                    }
                }
                sb.AppendLine($"---AlbumProducer: {s.Album.Producer.Name}");
                sb.AppendLine($"---Duration: {s.Duration.ToString("c")}");

                count++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
