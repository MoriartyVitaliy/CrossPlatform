using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using LabsLibrary;

namespace Lab5.Controllers
{
    [Authorize]
    public class LabsController : Controller
    {
        // Отображение страницы с выбором лабораторной работы
        [HttpGet]
        public IActionResult LabsOneToThree()
        {
            // Отображаем страницу с выбором лабораторной работы и пустым полем подсказки
            return View();
        }

        // Универсальный метод для запуска лабораторных работ
        [HttpPost]
        public IActionResult Execute(string labName, string inputData)
        {
            if (string.IsNullOrEmpty(labName) || string.IsNullOrEmpty(inputData))
            {
                ViewData["Error"] = "Please select a lab and provide input data.";
                return View("LabsOneToThree");
            }

            string tempDirectory = Path.GetTempPath();
            string inputFilePath = Path.Combine(tempDirectory, "input.txt");
            string outputFilePath = Path.Combine(tempDirectory, "output.txt");

            // Если файл ввода не существует, создаем его
            if (!System.IO.File.Exists(inputFilePath))
            {
                System.IO.File.Create(inputFilePath).Dispose();
            }

            // Записываем введенные данные в файл
            System.IO.File.WriteAllText(inputFilePath, inputData);

            // Запускаем лабораторную работу
            labName = labName.Replace(" ", string.Empty);
            LabExecutor.ExecuteLab(labName, inputFilePath, outputFilePath);

            // Читаем результат из файла вывода
            string outputContent = System.IO.File.ReadAllText(outputFilePath);

            // Удаляем временные файлы
            System.IO.File.Delete(inputFilePath);
            System.IO.File.Delete(outputFilePath);

            // Передаем результат на ту же страницу
            ViewData["Result"] = outputContent;
            ViewData["InputData"] = inputData;
            ViewData["LabName"] = labName;

            return View("LabsOneToThree");
        }
    }
}
