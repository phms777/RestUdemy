using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("sum/{numero1}/{numero2}")]
        public IActionResult Sum(string numero1, string numero2)
        {
            if (isANumber(numero1) && isANumber(numero2))
            {
                double total = convertToDecimal(numero1) + convertToDecimal(numero2);
                return Ok(total.ToString());

            }

            return BadRequest("Request not ok");
        }

        [HttpGet("sub/{numero1}/{numero2}")]
        public IActionResult Sub(string numero1, string numero2)
        {
            if (isANumber(numero1) && isANumber(numero2))
            {
                double total = convertToDecimal(numero1) - convertToDecimal(numero2);
                return Ok(total.ToString());

            }

            return BadRequest("Request not ok");
        }

        [HttpGet("div/{numero1}/{numero2}")]
        public IActionResult Div(string numero1, string numero2)
        {
            if (isANumber(numero1) && isANumber(numero2))
            {
                double total = convertToDecimal(numero1) / convertToDecimal(numero2);
                return Ok(total.ToString());

            }

            return BadRequest("Request not ok");
        }

        [HttpGet("mult/{numero1}/{numero2}")]
        public IActionResult Mult(string numero1, string numero2)
        {
            if (isANumber(numero1) && isANumber(numero2))
            {
                double total = convertToDecimal(numero1) * convertToDecimal(numero2);
                return Ok(total.ToString());

            }

            return BadRequest("Request not ok");
        }

        [HttpGet("sqtr/{numero}")]
        public IActionResult SqtRoot(string numero)
        {
            if (isANumber(numero))
            {
                double numberConvertedToDecimal = convertToDecimal(numero);
                if (numberConvertedToDecimal>=0)
                {
                    return Ok(Math.Sqrt(numberConvertedToDecimal).ToString());
                }
                else
                {
                    return BadRequest("Request not ok");
                }
            }

            return BadRequest("Request not ok");
        }
        private double convertToDecimal(string numero)
        {
            double valueConverted;
            if (double.TryParse(numero, out valueConverted))
            { 
                return valueConverted;
            }
            return 0;
            
        }

        private bool isANumber(string numero)
        {
            double number;
            bool isNumber = double.TryParse(numero, System.Globalization.NumberStyles.Any, 
                                            System.Globalization.NumberFormatInfo.InvariantInfo, 
                                            out number);
            return isNumber;
        }
    }
}
