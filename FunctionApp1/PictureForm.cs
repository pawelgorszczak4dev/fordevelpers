using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Table;

namespace FunctionApp1
{
    public class PictureForm : TableEntity
    {
        public string CustomerEmail { get; set; }
        public string FileName { get; set; }
        public double RequiredWidth { get; set; }
        public double RequiredHeight { get; set; }     
    }
}
