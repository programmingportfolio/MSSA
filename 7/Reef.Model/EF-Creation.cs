using Microsoft.EntityFrameworkCore;

namespace Reef.Model
{
    public class ReefSurvey : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Schools> Schools { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Reef-Survey;Trusted_Connection=True;");
        }
    }

    public class Location
    {
        public int LocationId { get; set; }
        public string RegionName { get; set; }
        public string SubRegionName { get; set; }
        public string StudyArea { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Management { get; set; }

    }

    public class Fish
    {
        public int FishId { get; set; }
        public string FamilyName { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public string Trophic { get; set; }

        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
    }

    public class Schools
    {
        public int SchoolsId { get; set; }

        //public string CommonName { get; set; }
        public double FishLength { get; set; }
        public double FishCount { get; set; }


        public int FishId { get; set; }
        public Fish Fish { get; set; }
    }

    public class Survey
    {
        public int SurveyId { get; set; }
        public string SurveyDate { get; set;  }
        public string SurveyYear { get; set; }
        public string BatchCode { get; set; }
        public int SurveyIndex { get; set; }

        //public int FishCount { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
