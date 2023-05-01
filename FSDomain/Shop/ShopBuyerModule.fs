module ShopBuyerModule

open ShopProductModule

type ShopBuyerName = string

type ShopBuyerOwnedProductList = ShopProduct list

type ShopBuyer = {
    name: ShopBuyerName
    ownedProducts: ShopBuyerOwnedProductList
}

let createNewBuyer (name : string) : ShopBuyer =
    { name = name; ownedProducts = [] }