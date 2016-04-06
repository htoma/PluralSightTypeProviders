module Movie.Data.MovieMain

open MovieData

type MovieSearchResult(result:option<Movie>) =
    member x.HasMovie = result <> None
    member x.Movie = 
        match result with
        | Some(movie) -> movie
        | _ -> invalidOp "no movie"

let GetMovieInfo name = async {
        let! infoWork = TheMovieDb.getMovieInfoByName name
                        |> Async.StartChild

        let! reviewWork = NYTimes.tryDownloadReviewByName name
                            |> Async.StartChild

        let! top100 = Netflix.getTop100()

        let! info = infoWork
        let! review = reviewWork        

        let basics = top100
                        |> Seq.tryFind (fun v -> v.Title = name)

        match basics, info with
        | Some(basics), Some(details, cast) ->
            return
                { Movie = basics
                  Details = details
                  Cast = cast
                  Review = review } |> Some |> MovieSearchResult
        | _ -> return None |> MovieSearchResult } |> Async.StartAsTask

let GetLatestMovies() = async {
     let! top100 = Netflix.getTop100()
     return top100 |> Seq.take 20 } |> Async.StartAsTask


        
                

