namespace MovieData

type MovieBasics = 
 { Title: string
   Summary: string
   Thumbnail: option<string> }

type Review = 
    { Published: System.DateTime
      Summary: string
      Link: string
      LinkText: string}

type Cast = 
    { Actor: string
      Character: string }

type Details = 
    { Homepage: string
      Genres: seq<string>
      Overview: string
      Companies: seq<string>
      Poster: string
      Countries: seq<string>
      Released: System.DateTime
      AverageVote: decimal }

type Movie = 
    { Movie: MovieBasics
      Details: Details
      Cast: seq<Cast>
      Review: option<Review> }

