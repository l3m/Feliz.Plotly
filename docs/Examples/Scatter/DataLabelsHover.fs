﻿[<RequireQualifiedAccess>]
module Samples.Scatter.DataLabelsHover

open Feliz
open Feliz.Plotly
open Fable.Core.Experimental

let chart () =
    Plotly.plot [
        plot.data [
            data.scatter [
                data.scatter.x [ 1; 2; 3; 4; 5]
                data.scatter.y [ 1; 6; 3; 6; 1 ]
                data.scatter.mode.markers
                data.scatter.name "Team A"
                data.scatter.text [ "A-1"; "A-2"; "A-3"; "A-4"; "A-5"]
                //data.scatter.marker [
                //    data.scatter.marker.size 12
                //]
            ]
            data.scatter [
                data.scatter.x [ 1.5; 2.5; 3.5; 4.5; 5.5 ]
                data.scatter.y [ 4; 1; 7; 1; 4 ]
                data.scatter.mode.markers
                data.scatter.name "Team B"
                data.scatter.text ["B-a" ; "B-b" ; "B-c" ; "B-d" ; "B-e" ]
                //data.scatter.marker [
                //    data.scatter.marker.size 12
                //]
            ]
        ]
        plot.layout [
            layout.xaxis [
                layout.xaxis.range [ 0.75; 5.25 ]
            ]
            layout.yaxis [
                layout.yaxis.range [ 0; 8 ]
            ]
            layout.title [
                layout.title.text "Data Labels Hover"
            ]
        ]
    ]