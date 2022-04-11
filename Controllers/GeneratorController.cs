using Microsoft.AspNetCore.Mvc;

namespace Logoped.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneratorController : ControllerBase
    {
        private readonly ILogger<GeneratorController> _logger;

        public GeneratorController(ILogger<GeneratorController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Generate")]
        public String[][] Post(GenerateWordsDTO dto)
        {

            return GenerateData(dto.Syllables!,dto.Columns,dto.Rows,dto.WordLength);
        }


        String RandomWord(int length, String syllables)
        {
            var result = "";

            var syllablesLocal = syllables.Split(',');

            for (var i = length; i > 0; --i)
            {
                result += syllablesLocal[int.Parse(Math.Floor(new Random().NextSingle() * syllablesLocal.Length).ToString())];
            }
            result = result.Replace(" ", "");

            return result;
        }

        String[][] GenerateData(String syllables, int columns, int rows, int wordLength)
        {
            var cols = new List<String>();
            for (int i = 0; i < columns; i++)
            {
                cols.Add(i.ToString());
            }

            var words = new String[rows][];
            for (int i = 0; i < rows; i++)
            {
                words[i] = new String[columns];
                for (int j = 0; j < columns; j++)
                {
                    words[i][j] = RandomWord(wordLength, syllables);
                }
            }

            return words;

        }
    }
}