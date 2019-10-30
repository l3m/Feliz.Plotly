﻿[<RequireQualifiedAccess>]
module Samples.PointCloud.Styled

open Feliz
open Feliz.Plotly

let chart () =
    Plotly.plot [
        plot.traces [
            traces.pointcloud [
                pointcloud.marker [
                    marker.sizemin 0.5
                    marker.sizemax 100
                    marker.border [
                        border.arearatio 0
                    ]
                    marker.color (colors.rgba(255, 0, 0, 0.6))
                ]
                pointcloud.x [ 0 .. 9 ]
                pointcloud.y [ 9 .. -1 .. 0 ]
            ]
            traces.pointcloud [
                pointcloud.marker [
                    marker.sizemin 0.5
                    marker.sizemax 100
                    marker.border [
                        border.arearatio 0
                    ]
                    marker.color (colors.rgba(0, 0, 255, 0.9))
                    marker.opacity 0.8
                    marker.blend true
                ]
                pointcloud.opacity 0.7
                pointcloud.x [ yield! [ 0 .. 9 ]; yield! [ 0 .. 9 ] ]
                pointcloud.y [ yield! [ 0 .. 9 ]; yield! List.replicate 10 0 ]
            ]
            traces.pointcloud [
                pointcloud.marker [
                    marker.sizemin 0.5
                    marker.sizemax 100
                    marker.border [
                        border.color (colors.rgb(0, 0, 0))
                        border.arearatio 0.7071
                    ]
                    marker.color colors.green
                    marker.opacity 0.8
                    marker.blend true
                ]
                pointcloud.opacity 0.7
                pointcloud.x [ 3.; 4.5; 6. ]
                pointcloud.y [ 9; 9; 9 ]
            ]
        ]
        plot.layout [
            layout.title [
                title.text "Basic Point Cloud"
            ]
            layout.xaxis [
                xaxis.type'.linear
                xaxis.range [ -2.501411175139456; 43.340777299865266 ]
                xaxis.autorange.true'
            ]
            layout.yaxis [
                yaxis.type'.linear
                yaxis.range [ 4; 6 ]
                yaxis.autorange.true'
            ]
            layout.height 598
            layout.width 1080
            layout.autosize true
            layout.showlegend false
        ]
    ]