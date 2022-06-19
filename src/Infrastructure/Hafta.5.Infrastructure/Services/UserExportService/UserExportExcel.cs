using Hafta._5.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta._5.Infrastructure.Services.UserExportService
{
    public class UserExportExcel
    {
        private UserManager<AppUser> _userManager;

        public UserExportExcel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public void Export()
        {
            List<AppUser> Users = _userManager.Users.ToList();

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();

            ExcelApp.Visible = false;
            Workbook workbook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet worksheet = workbook.Worksheets[1];
            for (int i = 1; i < Users.Count; i++)
            {
                ExcelApp.Cells[i, 1] = Users[i - 1].Nickname;
            }
            workbook.SaveAs($"E:\\DotNetWork\\UserLists{DateTime.Now.ToString("yyyy_MM_dd_HHmm")}.xlsx");
            workbook.Close();
        }
    }
}
