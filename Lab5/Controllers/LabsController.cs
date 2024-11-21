using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using LabsLibrary;

namespace Lab5.Controllers
{
    [Authorize]
    public class LabsController : Controller
    {
        [HttpGet]
        public IActionResult LabsOneToThree()
        {
            return View();
        }

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

            if (!System.IO.File.Exists(inputFilePath))
            {
                System.IO.File.Create(inputFilePath).Dispose();
            }

            System.IO.File.WriteAllText(inputFilePath, inputData);

            labName = labName.Replace(" ", string.Empty);
            LabExecutor.ExecuteLab(labName, inputFilePath, outputFilePath);

            string outputContent = System.IO.File.ReadAllText(outputFilePath);

            System.IO.File.Delete(inputFilePath);
            System.IO.File.Delete(outputFilePath);

            ViewData["Result"] = outputContent;
            ViewData["InputData"] = inputData;
            ViewData["LabName"] = labName;

            return View("LabsOneToThree");
        }
    }
}
