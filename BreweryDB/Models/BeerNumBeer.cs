using System;

namespace BreweryDB.Models
{
    public class BeerNumBeer
    {
        public string Input { get; set; }
        public bool ShowBeerNumbeer { get; set; }
        public BeerDetails BeerDetails { get; set; }
        public BeerAdvocate BeerAdvocate { get; set; }
        public Untappd Untappd { get; set; }
        public RateBeer RateBeer { get; set; }
        public Ratings Ratings { get; set; }
        public float MaxNumBeerMatches { get; set; }
        public string MostMatchedBeerName { get; set; }
        public string MostMatchedBrewery { get; set; }
        public string MostMatchedBeerNameAndBreweryHtml { get; set; }
        public BeerNumbeer BeerNumbeer { get; set; }
        public BeerNumbeerUserAvg BeerNumbeerUserAvg { get; set; }
        public string SessionId { get; set; }
        public string MostMatchedBeerNameAndBrewery { get; set; }
    }

    public class BeerMatch
    {
        public string BeerName { get; set; }
        public float NumMatches { get; set; }
        public double MatchStrength { get; set; }
        public bool UseRating { get; set; }
        public string UseRatingDisplay { get; set; }
    }

    public class BeerCommon
    {
        public string BeerName { get; set; }
        public string Brewery { get; set; }
        public string BeerNameAndBrewery { get; set; }
        public string Style { get; set; }
        public bool IsFound { get; set; }
        public BeerMatch BeerMatch { get; set; }
    }

    public class BeerDetails
    {
        public BeerCommon BeerCommon { get; set; }
        public string ABV { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public string NoResultsMessage { get; set; }
    }

    public class BeerAdvocate
    {
        public BeerCommon BeerCommon { get; set; }
        public string RatingSource { get; set; }
        public string BeerLink { get; set; }
        public float Rating { get; set; }
        public string NumberOfReviewers { get; set; }
        public string OutOfDisplay { get; set; }
        public string NoResultsMessage { get; set; }
        public string SourceTimeoutString { get; set; }
        public string RatingDisplay { get; set; }
    }

    public class Untappd
    {
        public BeerCommon BeerCommon { get; set; }
        public string RatingSource { get; set; }
        public string BeerLink { get; set; }
        public float Rating { get; set; }
        public string NumberOfReviewers { get; set; }
        public string OutOfDisplay { get; set; }
        public string NoResultsMessage { get; set; }
        public string SourceTimeoutString { get; set; }
        public string RatingDisplay { get; set; }
    }

    public class RateBeer
    {
        public BeerCommon BeerCommon { get; set; }
        public string RatingSource { get; set; }
        public string BeerLink { get; set; }
        public float Rating { get; set; }
        public string NumberOfReviewers { get; set; }
        public string OutOfDisplay { get; set; }
        public string NoResultsMessage { get; set; }
        public string SourceTimeoutString { get; set; }
        public string RatingDisplay { get; set; }
    }

    public class Ratings
    {
    }

    public class BeerNumbeer
    {
        public float Average { get; set; }
        public float AverageNotRounded { get; set; }
        public float Total { get; set; }
        public float ValidResults { get; set; }
        public bool ResultsMatch { get; set; }
    }

    public class BeerNumbeerUserAvg
    {
        public float Average { get; set; }
        public float AverageNotRounded { get; set; }
        public float Total { get; set; }
        public float ValidResults { get; set; }
        public bool ResultsMatch { get; set; }
    }
}
