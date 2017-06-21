using System;
using System.Collections.Generic;
using System.Linq;
using GOGOGO.Commons;
using Newtonsoft.Json;

namespace GOGOGO.BLL
{
    public static class MenuBll
    {
        public static List<Menu> GetMenus(string shopName)
        {
            return JsonConvert.DeserializeObject<List<Menu>>(FileHelper.Read(shopName)) ;
        }

        public static bool AddTodayMenus(string userName,string name,double price)
        {
            var todyMenu = new TodayMenu()
            {
                CreateTime = DateTime.Now,
                UserName = userName,
                Name = name,
                Price = price
            };
            var result = JsonConvert.DeserializeObject<List<TodayMenu>>(FileHelper.Read("todyorder"));
            if (result != null && result.Count > 0)
            {
                var firstOrDefault = result.FirstOrDefault();
                if (firstOrDefault != null && firstOrDefault.CreateTime.Date != DateTime.Now.Date)
                {
                    result.Clear();
                }
            }
            else
            {
                result = new List<TodayMenu>();
            }
            result.Add(todyMenu);
            FileHelper.WriteNew(JsonConvert.SerializeObject(result), "todyorder");
            return true;
        }
        public static List<TodayMenu> GetTodayMenus()
        {
            var list = JsonConvert.DeserializeObject<List<TodayMenu>>(FileHelper.Read("todyorder"));
            if (list != null && list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<TodayMenu>();
            }
        }

        public static object GetAvgPrice(int counts)
        {
            var list = JsonConvert.DeserializeObject<List<TodayMenu>>(FileHelper.Read("todyorder"));
            if (list != null && list.Count > 0)
            {

                return  new { AvgPrice = list.Sum(x => x.Price) / counts, TotalPrice = list.Sum(x => x.Price)};
            }
            else
            {
                return 0;
            }
        }
    }


    public class TodayMenu
    {
        public DateTime CreateTime { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Menu
    {
        /// <summary>
        /// 菜名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜价
        /// </summary>
        public double Price { get; set; }
    }
}