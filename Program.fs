// Learn more about F# at http://fsharp.org
(*
This macro generate a report of the hardware.
*)

open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.IO

open SolidEdgeCommunity.Extensions // https://github.com/SolidEdgeCommunity/SolidEdge.Community/wiki/Using-Extension-Methods
open SolidEdgeFramework
open SolidEdgeCommunity
open SolidEdgePart
open SolidEdgeDraft

open YamlDotNet

let username =
    System.Environment.UserName.ToLower()

[<EntryPoint>]
let main argv =
    // Connect with the opened SolidEdge application.
    let application = SolidEdgeCommunity.SolidEdgeUtils.Connect(true, true)

    // Info
    let applicationVersion = application.Value
    printfn "Author: recs@premiertech.com"
    printfn "Update: 2020-08-07"

    // Version validation
    if applicationVersion = "Solid Edge 2019" then printfn "Solid Edge 2019"
    else printfn "Unvalid version of solidedge"
    // else quite

    // Permissions
    printfn "User: %s" username
    if username = "slimane"
    // [
    //     "alba";
    //     "bouc11";
    //     "lapc3";
    //     "peld6";
    //     "fouj3";
    //     "cotk2";
    //     "nunk";
    //     "beam";
    //     "boum3";
    //     "morm8";
    //     "benn2";
    //     "recs";
    //     "slimane";
    //     "gils2";
    //     "albp";
    //     "tres2";
    // ]
    then printfn "permissions ... OK"
    else printfn "permissions ... Unvalid"

    //load yaml or json

    // Check the type of part
    let assemblyDocument = application.GetActiveDocument<SolidEdgeAssembly.AssemblyDocument>(false)
    let name = assemblyDocument.Name
    printfn "Name: %s" name

    // Check if the document is an assembly
    if application.ActiveDocumentType = DocumentTypeConstants.igAssemblyDocument then printfn "Assembly ... OK"

    // look for hardware elements (query)

    //  access properties of occurrence or cross data with JDE.

    // display a report of fasteners

    printfn "Done !"
    0
