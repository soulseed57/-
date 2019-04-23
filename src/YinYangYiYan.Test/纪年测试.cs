﻿namespace 阴阳易演.Test
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using 容器类;
    using 引用库;
    using 抽象类;
    using 查询类;

    [TestClass]
    public class 纪年测试
    {
        #region 计算方法
        public static 甲子 年柱计算(DateTime 时间, bool 公元后 = true)
        {
            var 年干余数 = 时间.Year % 10;
            var 年支余数 = 时间.Year % 12;
            var 年干序 = 公元后 ? 年干余数 - 3 : 8 - 年干余数;
            var 年支序 = (公元后 ? 年支余数 - 3 : 10 - 年支余数) + 3;
            var 年干 = 干支表.天干查询(年干序 - 1);
            var 年支表 = 常用方法.列表指定首位(干支表.地支列表.ToArray(), 8);
            var 年支 = 年支表[年支序];
            return new 甲子(年干, 年支);
        }
        public static 甲子 日柱计算(DateTime 时间)
        {
            var 公元年数 = 时间.Year;
            var 当年日数 = (int)(时间 - new DateTime(时间.Year, 1, 1)).TotalDays + 1;
            var 甲子余数 = ((公元年数 - 1) * 5 + (公元年数 - 1) / 4 + 当年日数) % 60;
            var 日干序 = 甲子余数 % 10 - 1;
            var 日支序 = 甲子余数 % 12 - 1;
            var 日干 = 干支表.天干查询(日干序);
            var 日支 = 干支表.地支查询(日支序);
            return new 甲子(日干, 日支);
        }
        public static 地支 换算时辰(DateTime 时间)
        {
            var 当天起始 = new DateTime(时间.Year, 时间.Month, 时间.Day);
            var 当前总时 = 时间 - 当天起始;
            var 时 = 当前总时.TotalHours;
            if (时 > 23 || 时 < 1)
            {
                return 地支.子;
            }
            if (1 < 时 && 时 < 3)
            {
                return 地支.丑;
            }
            if (3 < 时 && 时 < 5)
            {
                return 地支.寅;
            }
            if (5 < 时 && 时 < 7)
            {
                return 地支.卯;
            }
            if (7 < 时 && 时 < 9)
            {
                return 地支.辰;
            }
            if (9 < 时 && 时 < 11)
            {
                return 地支.巳;
            }
            if (11 < 时 && 时 < 13)
            {
                return 地支.午;
            }
            if (13 < 时 && 时 < 15)
            {
                return 地支.未;
            }
            if (15 < 时 && 时 < 17)
            {
                return 地支.申;
            }
            if (17 < 时 && 时 < 19)
            {
                return 地支.酉;
            }
            if (19 < 时 && 时 < 21)
            {
                return 地支.戌;
            }
            if (21 < 时 && 时 < 23)
            {
                return 地支.亥;
            }
            throw new Exception("未找到匹配的时辰");
        }
        public static 甲子 时柱计算(DateTime 时间)
        {
            var 时支 = 换算时辰(时间);
            var 支序 = 干支表.地支列表.IndexOf(时支);
            var 日干 = 日柱计算(时间).天干;
            var 首 = 干支历.五鼠遁(日干);
            var 序首 = 干支表.天干列表.IndexOf(首);
            var 干序 = 序首 + 支序;
            var 时干 = 干支表.天干查询(干序);
            var 时柱 = new 甲子(时干, 时支);
            return 时柱;
        }

        #endregion

        [TestMethod]
        public void 干支纪年测试()
        {
            var 纪年 = new 干支历(new DateTime(2018, 12, 9));

            Assert.IsTrue(纪年.年柱.名称 == "戊戌");
            Assert.IsTrue(纪年.月柱.名称 == "甲子");
            Assert.IsTrue(纪年.日柱.名称 == "乙亥");
        }

        [TestMethod]
        public void 甲子年份()
        {
            var showMsg = new StringBuilder();
            var 时间 = DateTime.Now;
            var yy = 时间.Year;

            //公元前后计算
            var after = yy;
            var 公元后 = new 干支历(时间);
            showMsg.AppendLine($"公元后{after}年:\t{公元后.年柱.名称}年 【{公元后.年柱.地支.生肖}年】");
            //干支纪年法
            var 甲子 = new 干支历(时间);
            showMsg.AppendLine($"阳历:{时间.Year}年{时间.Month}月{时间.Day}日");
            showMsg.AppendLine($"阴历:{甲子.阴历年}年{甲子.阴历月}月{甲子.阴历日}日");
            showMsg.AppendLine($"{甲子.年柱.名称}年 【{甲子.年柱.地支.生肖}年】");
            showMsg.AppendLine($"{甲子.月柱.名称}月 {甲子.日柱.名称}日 {甲子.时柱.名称}时");

            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 年月大写测试()
        {
            var showMsg = new StringBuilder();
            var date = DateTime.Now;
            var yearName = 干支历.年份名称(date.Year);
            var monthName = 干支历.月份名称(date.Month);
            var dayName = 干支历.日期名称(date.Day);
            showMsg.AppendLine($"阳历年:{yearName}{monthName}{dayName}");

            yearName = 干支历.年份名称(date.Year, false);
            monthName = 干支历.月份名称(date.Month, false);
            dayName = 干支历.日期名称(date.Day, false);
            showMsg.AppendLine($"阳历年:{yearName}{monthName}{dayName}");

            var jz = new 干支历(date);
            yearName = 干支历.年份名称(jz.阴历年);
            monthName = 干支历.月份名称(jz.阴历月);
            dayName = 干支历.日期名称(jz.阴历日);
            showMsg.AppendLine($"阴历年:{yearName}{monthName}{dayName}");

            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 月柱计算()
        {
            var 时间 = new DateTime(1995, 10, 21, 19, 53, 00);

            var 年柱 = 年柱计算(时间);
            var 月首 = 干支历.五虎遁(年柱.天干);
            var 节气 = 节气表.节气枚举查询(时间);
            var 月支 = 干支历.节气归支查询(节气);
            var 归月 = 干支历.节气归月查询(节气);
            var 首序 = 干支表.获取天干序数(月首);
            var 月干 = 干支表.天干查询(首序 + 归月 - 1);
            var 月柱 = new 甲子(月干, 月支);

            Assert.IsTrue(年柱.名称 == "乙亥");
            Console.WriteLine($"年柱:{年柱.名称}");

            Assert.IsTrue(月首.名称 == "戊");
            Console.WriteLine($"月干序首:{月首.名称}");

            Assert.IsTrue(月柱.名称 == "丙戌");
            Console.WriteLine($"节气:{节气} 月干:{月柱.天干.名称} 月支:{月柱.地支.名称}");

        }

        [TestMethod]
        public void 日柱计算()
        {

            var 日柱 = 日柱计算(new DateTime(2008, 3, 1));
            Assert.IsTrue(日柱.名称 == "庚子");
            Console.WriteLine($"日柱:{日柱.名称}");

            日柱 = 日柱计算(new DateTime(1995, 10, 21));
            Assert.IsTrue(日柱.名称 == "乙酉");
            Console.WriteLine($"日柱:{日柱.名称}");
        }

        [TestMethod]
        public void 时柱计算()
        {
            var 时间 = new DateTime(1995, 10, 21, 19, 53, 00);

            时间 = new DateTime(2019, 4, 21, 17, 55, 0);
            var 时支 = 换算时辰(时间);
            var 支序 = 干支表.地支列表.IndexOf(时支);
            var 日干 = 日柱计算(时间).天干;
            var 首 = 干支历.五鼠遁(日干);
            var 序首 = 干支表.天干列表.IndexOf(首);
            var 干序 = 序首 + 支序;
            var 时干 = 干支表.天干查询(干序);
            var 时柱 = new 甲子(时干, 时支);
            Console.WriteLine(时柱.名称);
            Assert.IsTrue(时柱.名称 == "辛酉");
            Assert.IsTrue(时柱计算(时间).名称 == "辛酉");
            Assert.IsTrue(干支历.时柱计算(时间).名称 == "辛酉");
        }

        [TestMethod]
        public void 干支历验证()
        {
            var 历 = new 干支历(new DateTime(1995, 10, 21, 19, 53, 0));
            Assert.IsTrue(历.年柱.名称 == "乙亥");
            Assert.IsTrue(历.月柱.名称 == "丙戌");
            Assert.IsTrue(历.日柱.名称 == "乙酉");
            Assert.IsTrue(历.时柱.名称 == "丙戌");

            历 = new 干支历(new DateTime(1987, 9, 1, 20, 45, 0));
            Assert.IsTrue(历.年柱.名称 == "丁卯");
            Assert.IsTrue(历.月柱.名称 == "戊申");
            Assert.IsTrue(历.日柱.名称 == "癸丑");
            Assert.IsTrue(历.时柱.名称 == "壬戌");
        }

    }
}
