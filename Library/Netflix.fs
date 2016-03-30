module Netflix

open FSharp.Data
open System.Text.RegularExpressions

let regexThumb = 
    Regex("<a[^>]*><img src=\"([^\"]*)\".*>(.*)")

type Netflix = 
    XmlProvider<"http://dvd.netflix.com/Top100RSS">

type MovieBasics = 
    { Title: string
      Summary: string
      Thumbnail: option<string> }

let getTop100() = 
    [ for it in Netflix.GetSample().Channel.Items ->
        let r = regexThumb.Match(it.Description)
        let desc, thumb = 
            if r.Success then
                r.Groups.[2].Value,
                Some(r.Groups.[1].Value)
            else
                it.Description, None
        { Title = it.Title
          Summary = desc
          Thumbnail = thumb}]
