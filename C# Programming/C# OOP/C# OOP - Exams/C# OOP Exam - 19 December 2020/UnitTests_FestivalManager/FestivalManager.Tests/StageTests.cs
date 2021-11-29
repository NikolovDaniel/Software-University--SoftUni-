namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;

		[SetUp] 
		public void Initialize()
        {
			stage = new Stage();
        }

		[Test]
		public void AddPerformer_ThrowExceptionWhenUnder18YearsOld()
        {
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Daniel", "Nikolov", 17)));
        }

		[Test]
		public void AddPerformer_CheckIfPerformerIsAdded()
        {
			int expectedCount = 1;

			stage.AddPerformer(new Performer("Daniel", "Nikolov", 25));

			int count = stage.Performers.Count;

			Assert.That(count, Is.EqualTo(expectedCount));
        }

		[Test]
		public void AddSong_ThrowExceptionWhenUnder18YearsOld()
		{
			Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("Let Her Go", new TimeSpan(0, 0, 25 ))));
		}

		[Test]
		public void AddSongToPerformer_CheckIfSongIsAddedCorrectly()
        {
			string songName = "Let Her Go";
			string performerName = "Daniel Nikolov";
			Performer performer = new Performer("Daniel", "Nikolov", 25);
			Song song = new Song(songName, new TimeSpan(0, 1, 25));

			stage.AddPerformer(performer);
			stage.AddSong(song);

			string output = stage.AddSongToPerformer(songName, performerName);
			string expectedMessage = $"{song} will be performed by {performer}";

			Assert.That(output, Is.EqualTo(expectedMessage));
		}

		[Test]
		public void Play_CheckIfReturnsCorrectString()
        {
			int n = 5;

            for (int i = 0; i < n; i++)
            {
				Performer performer = new Performer($"Daniel-{i}", "Nikolov", 25);
				Song song = new Song($"Song-{i}", new TimeSpan(0, 1, 25));
				stage.AddPerformer(performer);
				stage.AddSong(song);
				stage.AddSongToPerformer(song.Name, performer.FullName);
			}

			int perfCount = this.stage.Performers.Count;
			int songsCount = this.stage.Performers.Sum(x => x.SongList.Count);

			string receivedMessage = stage.Play();
			string expectedMessage = $"{perfCount} performers played {songsCount} songs";

			Assert.That(receivedMessage, Is.EqualTo(expectedMessage));
		}
	}
}