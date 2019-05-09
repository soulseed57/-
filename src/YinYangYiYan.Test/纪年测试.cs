﻿namespace 阴阳易演.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using 容器类;
    using 引用库;
    using 抽象类;
    using 枚举类;
    using 计算类;

    [TestClass]
    public class 纪年测试
    {
        [TestMethod]
        public void 干支纪年测试()
        {
            var 纪年 = new 干支历(new DateTime(2018, 12, 9));
            Assert.IsTrue(纪年.年柱.名称 == "戊戌");
            Assert.IsTrue(纪年.月柱.名称 == "甲子");
            Assert.IsTrue(纪年.日柱.名称 == "乙亥");
            var 时间 = new DateTime(1995, 1, 24, 18, 25, 0);
            var 历 = new 干支历(时间);
            //甲戌年 【狗年】丁丑月 乙卯日
            Assert.IsTrue(历.年柱.名称 == "甲戌");
            Assert.IsTrue(历.月柱.名称 == "丁丑");
            Assert.IsTrue(历.日柱.名称 == "乙卯");
            Console.WriteLine($"{历.年柱.名称}年{历.月柱.名称}月{历.日柱.名称}日");
        }

        [TestMethod]
        public void 日时测试()
        {
            var t = DateTime.MinValue;

            // 日柱测试1
            t = new DateTime(2008, 3, 1);
            干支历.日时计算(t, (日柱, 时柱) =>
            {
                Assert.IsTrue(日柱.名称 == "庚子");
                Console.WriteLine($"{t:yyyy年MM月dd日}\t日柱:{日柱.名称}");
            });

            // 日柱测试2
            t = new DateTime(1987, 9, 1, 20, 45, 0);
            干支历.日时计算(t, (日柱, 时柱) =>
            {
                Assert.IsTrue(日柱.名称 == "癸丑" && 时柱.名称 == "壬戌");
                Console.WriteLine($"{t:yyyy年MM月dd日 HH时}\t日柱:{日柱.名称}\t时柱:{时柱.名称}");
            });

            // 早子时1
            t = new DateTime(2019, 1, 1, 0, 0, 0);
            干支历.日时计算(t, (日柱, 时柱) =>
            {
                Assert.IsTrue(日柱.名称 == "戊戌" && 时柱.名称 == "壬子");
                Console.WriteLine($"{t:yyyy年MM月dd日 HH时mm分ss秒}\t日柱:{日柱.名称}\t时柱:{时柱.名称}");
            });

            // 早子时2
            t = new DateTime(2019, 1, 1, 0, 59, 59);
            干支历.日时计算(t, (日柱, 时柱) =>
            {
                Assert.IsTrue(日柱.名称 == "戊戌" && 时柱.名称 == "壬子");
                Console.WriteLine($"{t:yyyy年MM月dd日 HH时mm分ss秒}\t日柱:{日柱.名称}\t时柱:{时柱.名称}");
            });

            // 临近早子时
            t = new DateTime(2019, 1, 1, 1, 0, 0);
            干支历.日时计算(t, (日柱, 时柱) =>
            {
                Assert.IsTrue(日柱.名称 == "戊戌" && 时柱.名称 == "癸丑");
                Console.WriteLine($"{t:yyyy年MM月dd日 HH时mm分ss秒}\t日柱:{日柱.名称}\t时柱:{时柱.名称}");
            });

            // 临近晚子时
            t = new DateTime(2019, 1, 1, 22, 59, 59);
            干支历.日时计算(t, (日柱, 时柱) =>
            {
                Assert.IsTrue(日柱.名称 == "戊戌" && 时柱.名称 == "癸亥");
                Console.WriteLine($"{t:yyyy年MM月dd日 HH时mm分ss秒}\t日柱:{日柱.名称}\t时柱:{时柱.名称}");
            });

            // 晚子时1
            t = new DateTime(2019, 1, 1, 23, 0, 0);
            干支历.日时计算(t, (日柱, 时柱) =>
            {
                Assert.IsTrue(日柱.名称 == "己亥" && 时柱.名称 == "甲子");
                Console.WriteLine($"{t:yyyy年MM月dd日 HH时mm分ss秒}\t日柱:{日柱.名称}\t时柱:{时柱.名称}");
            });

            // 晚子时2
            t = new DateTime(2019, 1, 1, 23, 59, 59);
            干支历.日时计算(t, (日柱, 时柱) =>
            {
                Assert.IsTrue(日柱.名称 == "己亥" && 时柱.名称 == "甲子");
                Console.WriteLine($"{t:yyyy年MM月dd日 HH时mm分ss秒}\t日柱:{日柱.名称}\t时柱:{时柱.名称}");
            });

        }

        [TestMethod]
        public void 时辰早晚子测试()
        {
            for (var i = 0; i < 24; i++)
            {
                var times = new DateTime[]
                {
                    new DateTime(2019,1, 1, i, 0, 0),
                    new DateTime(2019,1, 1, i, 0, 1),
                    new DateTime(2019,1, 1, i, 59, 59),
                };
                foreach (var t in times)
                {
                    var 时辰 = t.时辰地支(out var 项);
                    Console.Write($"{t.Hour:D2}时{t.Minute:D2}分{t.Second:D2}秒\t{时辰.名称}时\t");
                    if (t.Hour == 0)
                    {
                        Assert.IsTrue(时辰.名称 == "子" && 项 == 时间计算.早晚子.早子时);
                    }
                    if (t.Hour == 1 && t.Minute == 0 && t.Second == 0)
                    {
                        Assert.IsTrue(时辰.名称 == "丑" && 项 == 时间计算.早晚子.无);
                    }
                    if (t.Hour == 2 && t.Minute == 0 && t.Second == 0)
                    {
                        Assert.IsTrue(时辰.名称 == "丑" && 项 == 时间计算.早晚子.无);
                    }
                    if (t.Hour == 2 && t.Minute == 59 && t.Second == 59)
                    {
                        Assert.IsTrue(时辰.名称 == "丑" && 项 == 时间计算.早晚子.无);
                    }
                    if (t.Hour == 3 && t.Minute == 0 && t.Second == 0)
                    {
                        Assert.IsTrue(时辰.名称 == "寅" && 项 == 时间计算.早晚子.无);
                    }
                    if (t.Hour == 23)
                    {
                        Assert.IsTrue(时辰.名称 == "子" && 项 == 时间计算.早晚子.晚子时);
                    }
                }
                Console.WriteLine();
            }
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

            历 = new 干支历(new DateTime(2019, 4, 22, 0, 1, 0));
            Assert.IsTrue(历.年柱.名称 == "己亥");
            Assert.IsTrue(历.月柱.名称 == "戊辰");
            Assert.IsTrue(历.日柱.名称 == "己丑");

            历 = new 干支历(new DateTime(1979, 8, 9, 7, 19, 0));
            Assert.IsTrue(历.年柱.名称 == "己未");
            Assert.IsTrue(历.月柱.名称 == "壬申");
            Assert.IsTrue(历.日柱.名称 == "戊申");
            Assert.IsTrue(历.时柱.名称 == "丙辰");
        }

        [TestMethod]
        public void 神煞测试()
        {
            Assert.IsTrue(干支历.日支时辰算神煞(地支.子, 地支.亥).名称 == "朱雀");
            Assert.IsTrue(干支历.日支时辰算神煞(地支.子, 地支.辰).名称 == "天牢");
            Assert.IsTrue(干支历.日支时辰算神煞(地支.子, 地支.申).名称 == "青龙");


            Assert.IsTrue(干支历.日支时辰算神煞(地支.申, 地支.辰).枚举 == 神煞枚举.金匮);
            Assert.IsTrue(干支历.日支时辰算神煞(地支.卯, 地支.亥).枚举 == 神煞枚举.玄武);
            Assert.IsTrue(干支历.日支时辰算神煞(地支.戌, 地支.未).枚举 == 神煞枚举.朱雀);

        }

        [TestMethod]
        public void 阴历测试()
        {
            var date = new ChineseCalendar(1979, 6, 17, true);
            Assert.IsTrue(date.Date.Month == 8);
            Assert.IsTrue(date.Date.Day == 9);
            Console.WriteLine($"农历:{date.ChineseDateString}");
            Console.WriteLine($"阳历:{date.Date:yyyy-MM-dd}");

            date = new ChineseCalendar(1979, 7, 18, false);
            Assert.IsTrue(date.Date.Month == 9);
            Assert.IsTrue(date.Date.Day == 9);
            Console.WriteLine($"农历:{date.ChineseDateString}");
            Console.WriteLine($"阳历:{date.Date:yyyy-MM-dd}");

            date = new ChineseCalendar(1979, 6, 17, false);
            Assert.IsTrue(date.Date.Month == 7);
            Assert.IsTrue(date.Date.Day == 10);
            Console.WriteLine($"农历:{date.ChineseDateString}");
            Console.WriteLine($"阳历:{date.Date:yyyy-MM-dd}");
        }
    }
}
