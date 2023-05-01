module SchoolCommonModule

type RangeLimit = int
type Price = decimal

type PriceRange = {
    rangeFrom: RangeLimit
    rangeTo: RangeLimit
    price: Price
}

let createPriceRange (startRange: RangeLimit) (interval: int) (price: Price) : PriceRange =
    { price = price; rangeFrom = startRange; rangeTo = startRange + interval }

let isPriceValid (price: Price) : bool =
    price >= 1m

type PriceRangesValidation = PriceRange -> PriceRange -> bool

let areConsecutiveRanges : PriceRangesValidation = fun (first:PriceRange) -> fun (second:PriceRange) -> first.rangeTo + 1 = second.rangeFrom

let isPriceDecreasing : PriceRangesValidation =
    fun (first:PriceRange) ->
        fun (second:PriceRange) ->
            first.price > second.price

let rec hasValidRanges (ranges: PriceRange list) : bool =
    match ranges with
    | [] -> true // Lista vazia
    | head :: _ when not (isPriceValid head.price) -> false // Primeiro elemento da lista com preço < 1
    | [_] -> true // Lista com 1 elemento
    | first :: second :: tail ->
        if not (areConsecutiveRanges first second) || not (isPriceDecreasing first second) then
            false
        else
            hasValidRanges (second :: tail)