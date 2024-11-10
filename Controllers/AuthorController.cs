using LibraryApiExample.Database;
using LibraryApiExample.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly DataSource _dataSource = DataSource.Instance();

        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<List<int>> Get()
        {
            var result = new List<int>();

            var cmd = _dataSource.Source.CreateCommand(
                $@"
                SELECT id FROM public.authors
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

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            var cmd = _dataSource.Source.CreateCommand(
                $@"
                SELECT id, name, surname, affiliation
                FROM public.authors 
                WHERE id={id};
                "
            );
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var type = new Author
                {
                    Id = reader["id"] as int?,
                    Name = reader["name"] as string,
                    Surname = reader["surname"] as string,
                    Affiliation = reader["affiliation"] as string
                };
                return type;
            }

            return null;
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async void Post([FromBody] Author value)
        {
            var cmd = _dataSource.Source.CreateCommand(
                $@"
                INSERT INTO public.authors (name, surname, affiliation) 
                VALUES ('{value.Name}', '{value.Surname}', '{value.Affiliation}');
                "
            );
            await cmd.ExecuteNonQueryAsync();
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Author value)
        {
            var cmd = _dataSource.Source.CreateCommand(
                $@"
                UPDATE public.authors
                SET 
                name='{value.Name}',
                surname='{value.Surname}',
                affiliation='{value.Affiliation}'
                WHERE id={id};
                "
);
            await cmd.ExecuteNonQueryAsync();
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var cmd = _dataSource.Source.CreateCommand(
                $@"
                DELETE FROM public.authors 
                WHERE id={id};
                "
);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
