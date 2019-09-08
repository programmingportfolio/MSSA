using Reef.Model;
using System;
using System.IO;

namespace Reef_Survey
{
    public class Parse
    {
        string Path { get; set; }

        public Parse(string path)
        {
            Path = path;
        }

        public void Csv()
        {
            bool arb = false;
            foreach (string line in File.ReadLines(Path))
            {
                int i = 0;
                if (arb == false)
                {
                    arb = true;
                    continue;
                }

                line.Trim();
                var dataArray = line.Split(",");
                string[] temp = new string[17];
                try
                {
                    using (var db = new ReefSurvey())
                    {
                        var theLocation = new Location { RegionName = dataArray[i], SubRegionName = dataArray[i + 1], StudyArea = dataArray[i + 2], Latitude = Convert.ToDouble(dataArray[i + 7]), Longitude = Convert.ToDouble(dataArray[i + 8]), Management = dataArray[i + 9] };
                        db.Locations.Add(theLocation);

                        var theSurvey = new Survey { Location = theLocation, SurveyYear = dataArray[i + 3], BatchCode = dataArray[i + 4], SurveyIndex = int.Parse(dataArray[i + 5]), SurveyDate = dataArray[i + 6] };
                        db.Surveys.Add(theSurvey);

                        var theFish = new Fish { Survey = theSurvey, FamilyName = dataArray[i + 11], ScientificName = dataArray[i + 12], CommonName = dataArray[i + 13], Trophic = dataArray[i + 14] };
                        db.Fish.Add(theFish);

                        var theSchools = new Schools { Fish = theFish, FishLength = double.Parse(dataArray[i + 15]), FishCount = double.Parse(dataArray[i + 16]) };
                        db.Schools.Add(theSchools);
                       
                        var count = db.SaveChanges();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
        }
    }
}
