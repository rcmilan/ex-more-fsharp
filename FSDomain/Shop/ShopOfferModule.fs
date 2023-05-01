module ShopOfferModule

open ShopProductModule

type ShopOfferName = string

type ShopOfferProductList = ShopProduct list

type ShopOffer = {
    name: ShopOfferName
    productsIn: ShopOfferProductList
}

let getOfferProducts (offer : ShopOffer) =
    offer.productsIn