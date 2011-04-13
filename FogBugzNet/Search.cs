namespace FogBugzNet
{
    public class Search
    {
        public Case[] Cases;
        public string Query;

        public Search()
        {
        }

        public Search(string query, Case[] cases)
        {
            Cases = cases;
            Query = query;
        }
    }
}