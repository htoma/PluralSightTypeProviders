module Netflix

open MovieData

open FSharp.Data
open System.Text.RegularExpressions

let regexThumb = 
    Regex("<a[^>]*><img src=\"([^\"]*)\".*>(.*)")

type Netflix = 
    XmlProvider<"http://dvd.netflix.com/Top100RSS">

let parseTop100 response = 
    seq {
          for it in Netflix.Parse(response).Channel.Items ->
            let r = regexThumb.Match(it.Description)
            let desc, thumb = 
                if r.Success then
                    r.Groups.[2].Value,
                    Some(r.Groups.[1].Value)
                else
                    it.Description, None
            { Title = it.Title
              Summary = desc
              Thumbnail = thumb}
         }

let getTop100() = async {
        let! response = Http.AsyncRequestString("http://dvd.netflix.com/Top100RSS") 
        return parseTop100(response)
    }