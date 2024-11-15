using Lab1.Library;

namespace Lab1.Tests
{
    public class FileServiceTests
    {
        private readonly IFileService _fileService;

        public FileServiceTests()
        {
            _fileService = new FileService();
        }

        [Fact]
        public void ReadInput_FileNotFound_ThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => _fileService.ReadInput("nonexistent.txt"));
        }

        [Fact]
        public void ReadInput_InvalidFormat_ThrowsFormatException()
        {
            // Создаем временный файл с неправильным форматом данных
            string filePath = "temp_invalid_format.txt";
            File.WriteAllText(filePath, "a1,b2,b3");

            var exception = Assert.Throws<FormatException>(() => _fileService.ReadInput(filePath));
            Assert.Equal("Invalid file format. Expected two coordinates separated by ', '.", exception.Message);

            File.Delete(filePath);
        }

        [Fact]
        public void ReadInput_ValidFile_ReturnsCorrectData()
        {
            // Создаем временный файл с правильными данными
            string filePath = "temp_valid_input.txt";
            File.WriteAllText(filePath, "a1, b2");

            var result = _fileService.ReadInput(filePath);
            Assert.Equal(new[] { "a1", "b2" }, result);

            File.Delete(filePath);
        }

        [Fact]
        public void WriteOutput_ValidFile_WritesContentCorrectly()
        {
            // Создаем временный файл для записи
            string filePath = "temp_output.txt";
            _fileService.WriteOutput(filePath, "1");

            var content = File.ReadAllText(filePath);
            Assert.Equal("1", content);

            File.Delete(filePath);
        }
    }
}