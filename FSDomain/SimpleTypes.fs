module SimpleTypes

type Name = string
type SpecialName = Name
type OptionalSpecialName = SpecialName option

type CompositeName =
    | FirstName of Name
    | FullName of Name * OptionalSpecialName

let createName (s : string) = Name s

let createSpecialName (s : string) = SpecialName(createName s)

let createSpecialNameFromName (n : Name) = SpecialName n

let createOptionalName (s : string) = 
    if s.Length = 0 then None
    else createSpecialName s |> Some

let createCompositeName (firstName: string) (lastName: OptionalSpecialName) =
    match (firstName, lastName) with
    | (f, Some l) -> FullName(createName firstName, Some(SpecialName l))
    | (f, None) -> FirstName(f)

let getCompositeName (cName: CompositeName) : string =
    match cName with
    | FirstName(n) -> n
    | FullName(f, Some l) -> f + " " + l
    | FullName(f, None) -> f