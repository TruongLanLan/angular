using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Data;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : Controller
    {
        private QuotesDbContext _quotesDbContext;
        public QuotesController(QuotesDbContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }
        // GET: QuotesController
        [HttpGet]
        [ResponseCache(Duration = 60, Location =ResponseCacheLocation.Any)]
        public IActionResult Get(string sort)
        {
            IQueryable<Quote> quotes;
            switch(sort)
            {
                case "desc":
                    quotes = _quotesDbContext.Quotes.OrderByDescending(p => p.CreateAt);
                    break;
                case "asc":
                    quotes = _quotesDbContext.Quotes.OrderBy(p => p.CreateAt);
                    break;
                default:
                    quotes = _quotesDbContext.Quotes;
                    break;
            }
            return Ok(quotes);
        }
        //Phantrang
        [HttpGet("[action]")]
        public IActionResult PagingQuote(int? pageNumber, int? pageSize)
        {
            var quotes = _quotesDbContext.Quotes;
            var currentPageNumber = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 5;
            return Ok(quotes.Skip((currentPageNumber - 1)* currentPageSize).Take(currentPageSize));
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult SearchQuote(string type)
        {
            var quotes = _quotesDbContext.Quotes.Where(p => p.Type.StartsWith(type));
            return Ok(quotes);
        }
        //Timkiem


        //public IEnumerable<Quote> Get()
        //{
        //    return _quotesDbContext.Quotes;
           
        //}
        //GET: api/Quotes/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            if(quote== null)
            {
                return NotFound("No record found...");
                
            }
            return Ok(quote);
        }

        //POST: api/Quotes
        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {
            _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
        //public void Post([FromBody] Quote quote)
        //{
        //    _quotesDbContext.Quotes.Add(quote);
        //    _quotesDbContext.SaveChanges();
        //}
        //Pust: api/Quotes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quote quote)
        {
            var entity = _quotesDbContext.Quotes.Find(id);
            if(entity == null)
            {
                return NotFound("No record found agianst this id...");
            }
            else
            {
                entity.Title = quote.Title;
                entity.Author = quote.Author;
                entity.Description = quote.Description;
                entity.Type = quote.Type;
                entity.CreateAt = quote.CreateAt;
                _quotesDbContext.SaveChanges();
                return Ok("Record Updaed Successfully...");
            }
            
        }
        //public void Put(int id, [FromBody] Quote quote)
        //{
        //   var entity =  _quotesDbContext.Quotes.Find(id);
        //    entity.Title = quote.Title;
        //    entity.Author = quote.Author;
        //    entity.Description = quote.Description;
        //    _quotesDbContext.SaveChanges();
        //}
        //delete: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _quotesDbContext.Quotes.Find(id);
            if(entity == null)
            {
                return NotFound("no record found agianst this id...");
            }
            else
            {
                _quotesDbContext.Quotes.Remove(entity);
                _quotesDbContext.SaveChanges();
                return Ok("Quote deleted...");
            }
            
        }
    }
}
