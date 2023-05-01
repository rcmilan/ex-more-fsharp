module CourseModule

open SchoolCommonModule

type CourseName = string

type CoursePriceRange = PriceRange

type Course = {
    name: CourseName
    priceRanges: CoursePriceRange list
}

let createCoursePriceRanges (quantity: int) (interval: int) (price: Price) : CoursePriceRange list =
    let rec generatePriceRanges remaining startRange currentPrice result =
        if remaining <= 0 || not (isPriceValid currentPrice) then
            List.rev result
        else
            let newPriceRange = createPriceRange startRange interval currentPrice
            let previousPriceRange = List.tryHead result
            match previousPriceRange with
            | Some prev when not (areConsecutiveRanges prev newPriceRange) || not (isPriceDecreasing prev newPriceRange) -> List.rev result
            | _ -> generatePriceRanges (remaining - 1) (startRange + interval + 1) (currentPrice - 1m) (newPriceRange :: result)

    generatePriceRanges quantity 1 price []

let isValidCourse (course: Course) : bool = hasValidRanges course.priceRanges