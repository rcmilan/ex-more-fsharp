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
    }
}
