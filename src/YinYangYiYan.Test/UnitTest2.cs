﻿namespace YinYangYiYan.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using 阴阳易演.具象类.五行;
    using 阴阳易演.引用库;
    using 阴阳易演.抽象类;
    using 阴阳易演.查询类;
    using 阴阳易演.计算类;

    [TestClass]
    public class UnitTest2
    {

        [TestMethod]
        public void 比和测试()
        {
            Assert.IsTrue(五行.比和(五行.土, 五行.土));
            Assert.IsFalse(五行.比和(五行.木, 五行.土));
            Assert.IsTrue(五行.比和(五行.金, 五行.金));
            Assert.IsTrue(五行.金.比和(五行.金));
            Assert.IsTrue(五行.木.比和(五行.木));
            Assert.IsFalse(五行.金.比和(五行.木));
        }

        [TestMethod]
        public void 生克关系()
        {
            Assert.IsInstanceOfType(五行.父母(五行.土), typeof(火));
            Assert.IsInstanceOfType(五行.子孙(五行.土), typeof(金));
            Assert.IsInstanceOfType(五行.官鬼(五行.土), typeof(木));
            Assert.IsInstanceOfType(五行.妻妾(五行.土), typeof(水));
            Assert.IsInstanceOfType(五行.兄弟(五行.土), typeof(土));

            Assert.IsInstanceOfType(五行.金.父母, typeof(土));
            Assert.IsInstanceOfType(五行.金.子孙, typeof(水));
            Assert.IsInstanceOfType(五行.金.官鬼, typeof(火));
            Assert.IsInstanceOfType(五行.金.妻妾, typeof(木));
            Assert.IsInstanceOfType(五行.金.兄弟, typeof(金));

            Assert.IsInstanceOfType(五行.金.子孙.子孙.子孙, typeof(火));
        }

        [TestMethod]
        public void 五行旺衰()
        {
            var showMsg = new StringBuilder();
            var 季节列表 = new List<季节> { 季节.春季, 季节.夏季, 季节.秋季, 季节.冬季, 季节.四季 };
            var 五行列表 = new List<五行> { 五行.金, 五行.木, 五行.水, 五行.火, 五行.土 };
            foreach (var 季 in 季节列表)
            {
                showMsg.Append($"{常用方法.获取类名(季)}\r\n");
                foreach (var 行 in 五行列表)
                {
                    showMsg.Append($"{常用方法.获取类名(行)}{季 + 行}\t");
                }
                showMsg.AppendLine();
                showMsg.Append($"{常用方法.获取类名(季.旺)}旺\t");
                showMsg.Append($"{常用方法.获取类名(季.相)}相\t");
                showMsg.Append($"{常用方法.获取类名(季.休)}休\t");
                showMsg.Append($"{常用方法.获取类名(季.囚)}囚\t");
                showMsg.Append($"{常用方法.获取类名(季.死)}死\t");
                showMsg.AppendLine();
            }
            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 天干阴阳()
        {
            var showMsg = new StringBuilder();
            foreach (var 干 in 干支表.阳干表)
            {
                showMsg.Append($"{常用方法.获取类名(干.阴阳)}");
                showMsg.Append($"{常用方法.获取类名(干.五行)}\t");
            }
            showMsg.AppendLine();
            foreach (var 干 in 干支表.阴干表)
            {
                showMsg.Append($"{常用方法.获取类名(干.阴阳)}");
                showMsg.Append($"{常用方法.获取类名(干.五行)}\t");
            }
            showMsg.AppendLine();

            var 天干干支 = new List<天干>
            {
                天干.甲,天干.丙,天干.戊,天干.庚,天干.壬,
                天干.乙,天干.丁,天干.己,天干.辛,天干.癸
            };
            foreach (var 干 in 天干干支)
            {
                showMsg.Append($"{常用方法.获取类名(干.五行)} ");
                showMsg.Append($"{常用方法.获取类名(干.阴阳)}\t");
            }
            showMsg.AppendLine();

            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 六十甲子()
        {
            var showMsg = new StringBuilder();
            var 天干表 = new List<天干> { 天干.甲, 天干.乙, 天干.丙, 天干.丁, 天干.戊, 天干.己, 天干.庚, 天干.辛, 天干.壬, 天干.癸 };
            var 地支表 = new List<地支> { 地支.子, 地支.丑, 地支.寅, 地支.卯, 地支.辰, 地支.巳, 地支.午, 地支.未, 地支.申, 地支.酉, 地支.戌, 地支.亥 };
            for (var i = 0; i < 60; i++)
            {
                var 干 = 天干表[i % 天干表.Count];
                var 支 = 地支表[i % 地支表.Count];
                var 甲子 = 干支关系.六十甲子(干, 支);
                showMsg.Append($"{甲子.名称}{甲子.序数:D2}\t");
                if ((i + 1) % 10 == 0) showMsg.Append("\r\n");
            }
            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 十二长生()
        {
            var showMsg = new StringBuilder();
            var 天干表 = 干支表.天干表;
            var 地支表 = 干支表.地支表;
            for (var i = 0; i < 60; i++)
            {
                var 干 = 天干表[i % 天干表.Length];
                var 支 = 地支表[i % 地支表.Length];
                showMsg.Append($"{常用方法.获取类名(干)}在{常用方法.获取类名(支)}:{干支关系.十二长生(干, 支)}\t");
                if ((i + 1) % 10 == 0) showMsg.Append("\r\n");
            }
            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 甲子数()
        {
            var showMsg = new StringBuilder();
            var all = 枚举转换类<甲子表.甲子枚举>.获取所有枚举();

            showMsg.AppendLine("枚举序数转换测试");
            foreach (var 枚举 in all)
            {
                var 序数 = 枚举转换类<甲子表.甲子枚举>.获取序数(枚举);
                showMsg.Append($"{枚举}[{序数:D2}]\t");
                if (序数 % 10 == 0) showMsg.AppendLine();
            }
            showMsg.AppendLine();

            showMsg.AppendLine("序数转甲子测试");
            foreach (var 枚举 in all)
            {
                var 序数 = 枚举转换类<甲子表.甲子枚举>.获取序数(枚举);
                var 甲数 = 甲子表.甲子查询(序数);
                showMsg.Append($"{甲数.名称}[{甲数.序数:D2}]\t");
                if (序数 % 10 == 0) showMsg.AppendLine();
            }
            showMsg.AppendLine();

            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 纳音五行()
        {
            var showMsg = new StringBuilder();
            for (var i = 1; i <= 60; i++)
            {
                var 甲子数1 = 甲子表.甲子查询(i);
                i++;
                var 甲子数2 = 甲子表.甲子查询(i);
                showMsg.Append($"{甲子数1.名称}{甲子数2.名称}.{甲子数1.纳音}\t");
                if (i % 10 == 0 && i != 1) showMsg.AppendLine();
            }
            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 甲子年份()
        {
            var showMsg = new StringBuilder();
            var 时间 = DateTime.Now;
            var yy = 时间.Year;

            //公元前后计算
            var after = yy;
            var 公元后 = new 干支纪年(时间);
            showMsg.AppendLine($"公元后{after}年:\t{公元后.年柱.名称}年 【{公元后.年柱.地支.生肖}年】");
            //干支纪年法
            var 甲子 = new 干支纪年(时间);
            showMsg.AppendLine($"阴历:{甲子.阴历年}年{甲子.阴历月}月{甲子.阴历日}日");
            showMsg.AppendLine($"{甲子.年柱.名称}年 【{甲子.年柱.地支.生肖}年】");
            showMsg.AppendLine($"{甲子.月柱.名称}月 {甲子.日柱.名称}日 {甲子.时辰.GetType().Name}时");
            //阴历月份转名称
            for (var i = 1; i <= 12; i++)
            {
                showMsg.Append($"{干支纪年.月份名称(i)} ");
            }
            showMsg.AppendLine();
            //阴历日期转名称
            for (var i = 1; i <= 31; i++)
            {
                showMsg.Append($"{干支纪年.日期名称(i)} ");
            }
            showMsg.AppendLine();

            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 时辰推算()
        {
            var showMsg = new StringBuilder();
            for (var i = 0; i < 24; i++)
            {
                var t = (i + 23) % 24;
                var time = 干支纪年.计算时辰(t).GetType().Name;
                showMsg.AppendLine($"{t:D2}点 {time}时");
            }
            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 阴历测试()
        {
            var showMsg = new StringBuilder();
            bool res;
            try
            {
                干支纪年.月份名称(-1);
                res = true;
            }
            catch
            {
                res = false;
            }
            Assert.IsFalse(res);
            try
            {
                干支纪年.月份名称(13);
                res = true;
            }
            catch
            {
                res = false;
            }
            Assert.IsFalse(res);
            try
            {
                干支纪年.日期名称(-1);
                res = true;
            }
            catch
            {
                res = false;
            }
            Assert.IsFalse(res);
            try
            {
                干支纪年.日期名称(32);
                res = true;
            }
            catch
            {
                res = false;
            }
            Assert.IsFalse(res);

            for (var i = 1; i <= 12; i++)
            {
                var 阴历月 = 干支纪年.月份名称(i);
                if (阴历月 == null) continue;
                showMsg.Append($"{i:D2}:{阴历月}\t");
                if (i % 4 == 0 && i != 0) showMsg.AppendLine();
            }
            showMsg.AppendLine();
            for (var i = 1; i <= 31; i++)
            {
                var 阴历日 = 干支纪年.日期名称(i);
                if (阴历日 == null) continue;
                showMsg.Append($"{i:D2}:{阴历日}\t");
                if (i % 10 == 0 && i != 0) showMsg.AppendLine();
            }
            showMsg.AppendLine();
            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 节气测试()
        {
            var showMsg = new StringBuilder();
            var date = DateTime.Now;
            showMsg.AppendLine($"当前节气:{二十四节气.节气查询(date)}");

            //修正儒略日测试
            var mjd = 二十四节气.日期转修正儒略日(date) ?? 0;
            var ymd = 二十四节气.修正儒略日转日期(mjd);
            showMsg.AppendLine($"日期:{date:yyyy/MM/dd}");
            showMsg.AppendLine($"修正儒略日:{mjd}");
            showMsg.AppendLine($"转换回日期:{ymd?.Year}/{ymd?.Month}/{ymd?.Day}");
            //节气判断测试
            var check = new DateTime(2017, 10, 7);
            showMsg.AppendLine($"查询时间:{check:yyyy/MM/dd},节气:{二十四节气.节气查询(check)}");
            //节气查询测试
            var st = 二十四节气.节气枚举.冬至;
            var stDate = 二十四节气.节气查询(date.Year, st);
            showMsg.AppendLine($"查询节气:{st},时间:{stDate.Year}-{stDate.Month}-{stDate.Day}");
            //节气设置测试
            var jq = new 二十四节气(2018, 二十四节气.节气枚举.立春);
            showMsg.AppendLine($"查询节气:{jq.名称} 日期:{jq.日期:yyyy-MM-dd}");
            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 年月大写测试()
        {
            var showMsg = new StringBuilder();
            var date = DateTime.Now;
            var yearName = 干支纪年.年份名称(date.Year);
            var monthName = 干支纪年.月份名称(date.Month);
            var dayName = 干支纪年.日期名称(date.Day);
            showMsg.AppendLine($"阳历年:{yearName}{monthName}{dayName}");

            yearName = 干支纪年.年份名称(date.Year, false);
            monthName = 干支纪年.月份名称(date.Month, false);
            dayName = 干支纪年.日期名称(date.Day, false);
            showMsg.AppendLine($"阳历年:{yearName}{monthName}{dayName}");

            var jz = new 干支纪年(date);
            yearName = 干支纪年.年份名称(jz.阴历年);
            monthName = 干支纪年.月份名称(jz.阴历月);
            dayName = 干支纪年.日期名称(jz.阴历日);
            showMsg.AppendLine($"阴历年:{yearName}{monthName}{dayName}");

            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 四季判断()
        {
            var showMsg = new StringBuilder();
            for (var i = 0; i < 24; i++)
            {
                var 节气 = (二十四节气.节气枚举)Enum.ToObject(typeof(二十四节气.节气枚举), i);
                var 时间 = 二十四节气.节气查询(2017, 节气);
                var 季节名 = 季节.季节判断(时间).GetType().Name;
                showMsg.AppendLine($"{节气}:{时间:MM-dd}\t{季节名}");
            }
            var t = new DateTime(2017, 1, 1);
            var r = new Random();
            var d = r.Next(365);
            var date = t.AddDays(d);
            var season = 季节.季节判断(date).GetType().Name;
            showMsg.AppendLine($"{date:yyyy-MM-dd}\t{season}");

            Console.Write(showMsg.ToString());
        }

    }
}