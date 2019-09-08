namespace Reef_Survey
{
    class App
    {
        public void Run()
        {
            var parse = new Parse(@"..\..\..\external\survey\1-data\Fish Dump.csv");
            parse.Csv();
        }
    }
}
