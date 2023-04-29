module ProductModule

type ProductPrice = 
    | Price of decimal
    | None

type ProductName = string
type ProductAvailability = bool

type Product = {
    name : ProductName
    price : ProductPrice
    isAvailable : ProductAvailability
}

let createNew (name : string) (price : decimal) (isAvailable : bool) =
    { name = name; price = Price price; isAvailable = isAvailable }

let updateName (newName : string) (p : Product) : Product =
    { p with name = newName }

type ProductContainer = {
    productList : Product list
}

let emptyContainer : ProductContainer = { productList = [] }

let addProduct (product : Product) (container : ProductContainer) : ProductContainer =
    { container with productList = product :: container.productList }