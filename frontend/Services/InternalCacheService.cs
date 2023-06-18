namespace frontend.Services
{
    public class InternalCacheService
    {
        //save the API Ids of the favourites
        private List<string> _favourites;

        public InternalCacheService() 
        { 
            _favourites = new List<string>();
        }

        public void AddToFavourites(string NewFavourite)
        {
            _favourites.Add(NewFavourite);
        }

        public bool IsInFavourites(string IdToCheck)
        {
            var result = _favourites.Find(f => f == IdToCheck);
            return result != default;
        }
    }
}
