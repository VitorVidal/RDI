using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        private readonly ICardService cardService;
        public CardController(ICardService cardService)
        {
            this.cardService = cardService?? throw new ArgumentNullException(nameof(cardService));
        }

        /// <summary>
        /// Generate a token for cashless registration.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="customerCard">Schema receiveCardRequest</param>
        /// <returns>Token</returns>
        /// <response code="200">Returns the token</response>
        /// <response code="400">If the any of the customerCard properties are null or invalid.</response>       
        [HttpPost("~/GenerateToken")]      
        [ProducesResponseType(typeof(receiveCardResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateToken([FromBody][Required] receiveCardRequest customerCard)
        {

            if (customerCard == null) return BadRequest();

            receiveCardResponse response = await cardService.Save(customerCard);

            return Ok(response);
        }

        /// <summary>
        /// Validate that token based on data provided.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="token">Schema validateTokenRequest</param>
        /// <returns>A boolean indicating that the token is valid or not </returns>
        /// <response code="200">returns true or false.</response>
        /// <response code="400">If the any of the token properties are null or invalid.</response>
        [HttpPost("~/ValidateToken")]       
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidateToken([FromBody][Required] validateTokenRequest token)
        {

            if (token == null) return BadRequest();

            bool result = await cardService.ValidateToken(token);

            return Ok(result);
        }
    }
}
