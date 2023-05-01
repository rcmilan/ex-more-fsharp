module ShopActionModule

open ShopProductModule
open ShopOfferModule
open ShopBuyerModule

let product3 : ShopProduct = { name = "product3" }
let product4 : ShopProduct = { name = "product4" }

let productList : ShopProduct list = [{ name = "product1" }; { name = "product2" }; product3; product4]

let offer1 : ShopOffer = { name="Offer1"; productsIn = productList}
let offer2 : ShopOffer = { name="Offer2"; productsIn = [product3; product4]}

let addOfferToBuyer (offer : ShopOffer) (buyer : ShopBuyer) = 
    let offerProducts = getOfferProducts offer
    { buyer with ownedProducts = offerProducts @ buyer.ownedProducts }