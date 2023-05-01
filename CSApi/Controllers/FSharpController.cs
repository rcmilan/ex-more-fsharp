using CSApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FSharpController : ControllerBase
    {
        [HttpGet("Name")]
        public IActionResult GetName(string n)
        {
            var optionalName = SimpleTypes.createOptionalName(n);

            return Ok(optionalName.Value);
        }

        [HttpGet("CompositeName")]
        public IActionResult GetCompositeName(string n)
        {
            var names = n.Split("-");

            var cName = SimpleTypes.createCompositeName(names[0], names[1]);

            var r = SimpleTypes.getCompositeName(cName);

            return Ok(r);
        }

        [HttpGet("Person")]
        public IActionResult Person()
        {
            var d = CompositeTypes.SpecialDocument.NewText("aaa");
            var n = CompositeTypes.SpecialDocument.NewNumber(123);

            var p1 = new CompositeTypes.Person("aaa", d);
            var p2 = new CompositeTypes.Person("aaa", n);

            var docP2 = CompositeTypes.getSpecialDocument(p2);

            return Ok(docP2);
        }

        [HttpGet("Product")]
        public IActionResult GetProduct()
        {
            var p1 = ProductModule.createNew("prod1", 1, true);
            var p2 = new ProductModule.Product("prod2", ProductModule.ProductPrice.None, true);

            p1 = ProductModule.updateName("new name p1", p1);

            var pc = ProductModule.emptyContainer;

            var pl = new List<ProductModule.Product>
            {
                p1, p2, p1, p2
            };

            foreach (var p in pl) pc = ProductModule.addProduct(p, pc);

            foreach (var p in pc.productList)
            {
                var name = p.name;
                var price = p.price;
            }

            return Ok();
        }

        [HttpGet("Shop")]
        public IActionResult GetShop()
        {
            var buyer = ShopBuyerModule.createNewBuyer("New Buyer");

            var offer = ShopActionModule.offer3;

            buyer = ShopActionModule.addOfferToBuyer(offer, buyer);

            var buyerOwnedProducts = buyer.ownedProducts.Select(p => p.name);

            return Ok(buyerOwnedProducts);
        }

        [HttpGet("School")]
        public IActionResult GetSchool()
        {
            var course1 = CourseModule.createCourse("Curso1");
            var course2 = CourseModule.createCourse("Curso2");

            var cPriceRanges1 = CourseModule.createCoursePriceRanges(3, 2, 100);
            var cPriceRanges2 = CourseModule.createCoursePriceRanges(4, 10, 200);

            course1 = CourseModule.addPriceRangesToCourse(course1, cPriceRanges2);
            course2 = CourseModule.addPriceRangesToCourse(course2, cPriceRanges1);

            var school = SchoolModule.createSchool("Escola 1");

            school = SchoolModule.addCourseToSchool(school, course1);
            school = SchoolModule.addCourseToSchool(school, course2);

            if(SchoolModule.isValidSchool(school))
            {
                var courses = school.courses.Select(c => {
                    var priceRanges = c.priceRanges.Select(pr => new CoursePriceRangeDto(pr.rangeFrom, pr.rangeTo, pr.price));
                    return new CourseDto(c.name, priceRanges);
                });

                var result = new SchoolDto(school.name, courses);

                return Ok(result);

            }

            return Problem();
        }
    }
}
