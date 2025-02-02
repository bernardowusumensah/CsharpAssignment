using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Assignment1Controller : ControllerBase
    {

        // GET: localhost:xx/api/Assignment1 -> "welcome to 5125!"
        // <summary>//An HttpGet method that outputs a string "Welcome to 5125!" </summary>
        //<return> A welcome message of introduction to the course Http 5125 </return>
        //<param>This HttpMethod does not accept input parameters </param>
        // <example> GET   api/Assignment/WelcomeMessage   -> Welcome 5125! </example>
        [HttpGet(template: "/api/Assignment1/")]
        public string WelcomeMessage()
        {
            return "Welcome to 5125!";
        }


        // GET: localhost:xx/api/Assignment1/greeting -> "name"
        // <summary>Receives an HTTP GET request with one query parameter and provides
        // a response message</summary>

        //<return> An HTTP response indicating the usage,
        //echoing the value of the query parameter and as well in the url</return>

        //<example>
        /// GET api/Assignment1/greeting?name=Bernard-> Get method with one parameter.
        /// name: Bernard <summary>
        /// </example>

        /// <param name="name">Hi name</param>

        [HttpGet(template: "/api/Assignment1/greeting")]
        public string greeting(string name)
        {

            return ($"Hi {name}!");
        }
        
        /// <summary>
        /// An HttpGet Method that multiplies a number 
        /// by itself 3 times
        /// </summary>
        /// <param name="number"></param>
        /// <returns>returns a cube of the number entered</returns>
        /// <example>
        /// 3^3 = 3*3*3
        /// </example>

        [HttpGet(template: "/api/Assignment1/Cube/{number}")]
        public int Cube(int number)
        {

            return number * number * number;
        }


        // POST: localhost:7289/api/Assignment1/knockknock
        // REQUEST HEADERS: (NONE)
        //REQUEST BODY: (NONE)
        /// <summary>
        /// An HttpPost method that returns greetings to a 
        /// user when endpoint is reached
        /// </summary>
        /// <returns>
        /// returns a greeting message "who is there"
        /// </returns>
        /// <example>
        /// Who is there?
        /// </example>
        [HttpPost(template: "/api/Assignment1/knockknock/")]

        public string knockknock()
        {
            return "Who is there?";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="integer"></param>
        /// <returns>
        /// Returns the concatenation of the input interger 
        /// to a string "the secret is"
        /// </returns>
        /// <example>shh the secret is 7</example>

        [HttpPost(template: "/api/Assignment1/secretInteger/secret")]
        public string secretInteger(int integer)
        {
            return "Shh.. the secret is " + integer;
        }

        /// <summary>
        /// An HttpGet Method that calculates 
        /// the area of a regular hexagon with
        /// side length double
        /// </summary>
        /// <param name="side"></param>
        /// <returns>returns area of a hexagon/returns>
        /// <example>
        /// with a side length of 4, the area is 41.569219381653056
        /// </example>

        [HttpGet(template: "/api/Assignment1/hexagon/side")]
        public double  hexagon(double side)
        {

            double area = Math.Pow(side, 2);
            double squareRoot = Math.Sqrt(3);
            double multiply = 3 * squareRoot;
            double divide = multiply / 2;

            double hexvalue = divide * area;
            return hexvalue;
            ;
        }


        /// <summary>
        ///  Adjusting the DateTime function from(past or old days)
        ///  and to (new or days ahead) by any number as (days) either the
        ///  going forward or the going backward (-,+ values) standing on 
        ///  the current/today
        /// </summary>
        /// <param name="days"></param>
        /// <returns>returns a dateTime to string per the 
        /// number of days supplied
        /// </returns>
        /// <example>
        /// 1. today's date is 2025-02-01, adding the number 1 takes me to 
        /// tomorrow 2025-02-02
        /// 2. today's date is 2025-02-01, adding the number -1 takes me to 
        /// yesterday 2025-01-31
        /// </example>


        [HttpGet(template: "/api/Assignment1/timemachine/date")]
        public string GetDateAdjustment([FromQuery]  int days)
        {


            DateTime adjustedDate = DateTime.Today.AddDays(days);

            return adjustedDate.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// calculation of cart items taken into consideration
        /// the small size, the large size, the unit cost of each, 
        /// deductible tax amount and the total cost after.
        /// </summary>
        /// <param name="small"></param>
        /// <param name="large"></param>
        /// <returns>
        /// Returns a cart of plushie items. 
        /// </returns>
        /// <example>
        /////    "smallSummary": "5 Small @ $25.5 = $127.5",
        //      "largeSummary": "6 Large @ $40.5 = $243",
        //      "beforeTax": "$370.5",
        //      "taxValue": "$48.165 HST",
        //      "priceAfterTax": "$418.665"
        /// </example>

        [HttpPost(template:"api/Assignment1/squashfellows/")]

        public IActionResult OrderCheckout(int small, int large)
        {

            //const variable declarations 

            double smallPrice = 25.50;
            double largePrice = 40.50;
            

            // calculate subTotals

            double smallPlushieValue = smallPrice * small;
            double largePlushieValue = largePrice * large;
            double orderItemsPrice = smallPlushieValue + largePlushieValue;

                // After Tax
            double taxValue = 0.13 * orderItemsPrice;

            // CheckOutPrice

            double cartTotalPrice = orderItemsPrice + taxValue;

            //rounding calculated values to the nearest decimal of two
            smallPlushieValue  = Math.Round(smallPlushieValue, 2);
            largePlushieValue = Math.Round(largePlushieValue,2);
            orderItemsPrice = Math.Round(orderItemsPrice, 2);

            


            var orderSummary = new
            {
                smallSummary = $"{small} Small @ ${smallPrice} = ${smallPlushieValue}",
                LargeSummary = $"{large} Large @ ${largePrice} = ${largePlushieValue}",
                beforeTax = $"${orderItemsPrice}",
                taxValue = $"${taxValue} HST",
                PriceAfterTax = $"${cartTotalPrice}"
               
        };




            return Ok(orderSummary);

        }

    }
}
