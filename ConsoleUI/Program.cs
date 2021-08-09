using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CliemManager cliemManager = new CliemManager(new EfCliemDal());
            string email = "anilcetinnn2@yandex.com";

            foreach (var cliem in cliemManager.GetAll().Data)
            {
                Console.WriteLine(cliem.cliem_title);
            }
        }
    }
}
