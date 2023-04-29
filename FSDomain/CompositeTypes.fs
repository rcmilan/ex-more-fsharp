module CompositeTypes

type Document = string

type SpecialDocument = Text of Document | Number of int

type Person = {
    name : string
    doc : SpecialDocument
}

let getSpecialDocument (p:Person) : string =
    match p.doc with
    | Text(d) -> d
    | Number(n) -> n.ToString()