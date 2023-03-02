using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {

            List<IDye> dyes = bunny.Dyes.ToList();

            if (bunny.Energy > 0 && dyes.Count > 0)
            {
                IDye dye = bunny.Dyes.FirstOrDefault();

                while (!egg.IsDone() && bunny.Energy > 0 && bunny.Dyes.Count > 0)
                {
                    if (dye.Power == 0)
                    {
                        bunny.Dyes.Remove(dye);
                        dye = bunny.Dyes.FirstOrDefault();
                    }

                    if (dye == null)
                    {
                        break;
                    }

                    dye.Use();
                    bunny.Work();
                    egg.GetColored();
                }
            }
        }
    }
}
