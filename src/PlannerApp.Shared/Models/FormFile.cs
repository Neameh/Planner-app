using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Models
{
    public class FormFile
    {
        public FormFile(Stream fileStream, string fileName)
        {
            FileStream = fileStream;
            FileName = fileName;
        }

        public Stream FileStream { get; set; }
        public string FileName { get; set; }

    }
}
