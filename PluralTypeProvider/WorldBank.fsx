#r "../packages/FSharp.Data.2.2.5/lib/net40/Fsharp.Data.dll"

open FSharp.Data

let wb = WorldBankData.GetDataContext()
wb.Countries.Romania.CapitalCity
wb.Countries.Belgium.Indicators.``Population in largest city``.[2013]

for country in wb.Regions.``Arab World``.Countries do
    let gdp = country.Indicators.``GDP, PPP (current international $)``.[2014]
    let gdpBil = gdp / 1.0e9
    printfn "%s: %.2f" country.Name gdpBil