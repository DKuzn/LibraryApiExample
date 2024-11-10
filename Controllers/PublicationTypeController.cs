using LibraryApiExample.Database;
using LibraryApiExample.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationTypeController : ControllerBase
    {
        private readonly DataSource _dataSource = DataSource.Instance();

        // GET: api/<PublicationTypeController>
        [HttpGet]
        public async Task<List<int>> Get()
        {
            var result = new List<int>();

            var cmd = _dataSource.Source.CreateCommand(
                $@"
                SELECT id FROM public.publication_types 
                ORDER BY id ASC;
                "
            );
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(reader.GetInt32(0));
            }

            return result;
        }

        // GET api/<PublicationTypeController>/5
        [HttpGet("{id}")]
        public async Task<PublicationType?> Get(int id)
        {
            var cmd = _dataSource.Source.CreateCommand(
                $@"
                SELECT id, type 
                FROM public.publication_types 
                WHERE id={id};
                "
            );
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var type = new PublicationType
                {
                    Id = reader["id"] as int?,
                    Type = reader["type"] as string
                };
                return type;
            }

            return null;
        }

        // POST api/<PublicationTypeController>
        [HttpPost]
        public async void Post([FromBody] PublicationType value)
        {
            var cmd = _dataSource.Source.CreateCommand(
                $@"
                INSERT INTO public.publication_types (type) 
                VALUES ('{value.Type}');
                "
            );
            await cmd.ExecuteNonQueryAsync();
        }

        // PUT api/<PublicationTypeController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] PublicationType value)
        {
            var cmd = _dataSource.Source.CreateCommand(
                $@"
                UPDATE public.publication_types
                SET type='{value.Type}'
                WHERE id={id};
                "
);
            await cmd.ExecuteNonQueryAsync();
        }

        // DELETE api/<PublicationTypeController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var cmd = _dataSource.Source.CreateCommand(
                $@"
                DELETE FROM public.publication_types 
                WHERE id={id};
                "
);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
