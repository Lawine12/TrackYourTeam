using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTrackOfYourTeam
{
    public abstract class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public int CoachId { get; set; }
    }

    public class Coach : Team
    {
        public int Id { get; set; }

        public int YearsExperience { get; set; }

        public int PersonId { get; set; }
    }

    public class Players : Team
    {
        public int Id { get; set; }

        public string Position { get; set; }

        public int PersonId { get; set; }

        public int TeamId { get; set; }
    }

    public class Person : Players
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        
        public string LastName { get; set; }

        public string Adres { get; set; }

        public string City { get; set; }

        public DateTime BirthDate { get; set; }


    }
}
