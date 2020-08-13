using MenuService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MenuService.Services
{
    public class Operations
    {
        
        public static int ComputeMenuIdSum(Menu menuToProcess)
        {
            int sum = 0;

            var labelledMenuItems = menuToProcess.Items.Where(x => x != null).Where(x => !string.IsNullOrEmpty(x.Label)).Select(x => x.Id).ToList();

            if (labelledMenuItems.Any())
            {
                sum = labelledMenuItems.Sum();
            }

            return sum;
        }

        public static List<MenuContainer> GetMenuListFromFile(string inputFilePath)
        {
            var Menus = new List<MenuContainer>();
            if (File.Exists(inputFilePath))
            {
                using (StreamReader r = new StreamReader(inputFilePath))
                {
                    var jsonString = r.ReadToEnd();
                    Menus = JsonConvert.DeserializeObject<List<MenuContainer>>(jsonString);
                }
            }
            
            return Menus;
        }
    }
}
