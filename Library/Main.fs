module Movie.Data.MovieMain

open MovieData

type MovieSearchResult(result:option<Movie>) =
    member x.HasMovie = result <> None
    member x.Movie = 
        match result with
        | Some(movie) -> movie
        | _ -> invalidOp "no movie"

let GetMovieInfo name = 
    let info = 
        TheMovieDb.tryGetMovieId name
        |> Option.map (fun id -> 
            TheMovieDb.getMovieDetails id,
            TheMovieDb.getMovieCast id)

    let review = NYTimes.tryDownloadReviewByName name

    let basics = Netflix.getTop100()
                    |> Seq.tryFind (fun v -> v.Title = name)

    match basics, info with
    | Some(basics), Some(details, cast) ->
        { Movie = basics
          Details = details
          Cast = cast
          Review = review } |> Some |> MovieSearchResult
    | _ -> None |> MovieSearchResult

let GetLatestMovies() =
    Netflix.getTop100() |> Seq.take 20


        
                

