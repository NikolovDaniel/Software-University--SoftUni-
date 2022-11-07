using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == true && racerTwo.IsAvailable() == false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == true)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }

            racerOne.Race();
            racerTwo.Race();

            double chanceOfWinningPlayerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * (racerOne.RacingBehavior == "strict" ? 1.2 : 1.1);
            double chanceOfWinningPlayerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * (racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1);

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username,
                chanceOfWinningPlayerOne > chanceOfWinningPlayerTwo ? racerOne.Username : racerTwo.Username);
        }
    }
}
